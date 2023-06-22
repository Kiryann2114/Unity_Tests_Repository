using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fire : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource WeaponAudio;
    public Transform fpsCamera;
    private RaycastHit hit;
    private bool pressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == gameObject)
        {
            if (DataHolder.Weapons[DataHolder.ActivIndex].Bullets > 0)
            {
                pressed = true;
                if (!DataHolder.Weapons[DataHolder.ActivIndex].Autofire)
                {
                    Shot();
                    DataHolder.Weapons[DataHolder.ActivIndex].Bullets--;
                }
                else
                {
                    StartCoroutine(waiter());
                }
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    IEnumerator waiter()
    {
        while (pressed)
        {
            Shot();
            DataHolder.Weapons[DataHolder.ActivIndex].Bullets--;
            yield return new WaitForSeconds(DataHolder.Weapons[DataHolder.ActivIndex].betweenShotsTime);
        }
    }
    private void Update()
    {
        if (DataHolder.Weapons[DataHolder.ActivIndex].Bullets == 0)
        {
            pressed = false;
        }
    }

    private void Shot()
    {
        WeaponAudio.PlayOneShot(DataHolder.Weapons[DataHolder.ActivIndex].Shot);
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, DataHolder.Weapons[DataHolder.ActivIndex].range))
        {
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<EnemyController>().HP -= DataHolder.Weapons[DataHolder.ActivIndex].damage;
            }
        }
    }
}
