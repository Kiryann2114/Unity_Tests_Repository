using System.Collections;
using UnityEngine;

public class Reloading : MonoBehaviour
{
    public AudioSource WeaponAudio;
    public AudioClip ReloadClip;
    public Animator Animator;
    public void Reload()
    {
        if (DataHolder.Weapons[DataHolder.ActivIndex].Bullets < DataHolder.Weapons[DataHolder.ActivIndex].maxBullets)
        {
            WeaponAudio.PlayOneShot(ReloadClip);
            StartCoroutine(waiter());
        }
    }
    IEnumerator waiter()
    {
        Animator.SetBool("Reload", true);
        yield return new WaitForSeconds(DataHolder.Weapons[DataHolder.ActivIndex].reloadTime);
        DataHolder.Weapons[DataHolder.ActivIndex].Bullets = DataHolder.Weapons[DataHolder.ActivIndex].maxBullets;
        Animator.SetBool("Reload", false);
    }
}
