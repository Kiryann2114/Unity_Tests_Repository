using UnityEngine;
using UnityEngine.UI;

public class WeaponSettings : MonoBehaviour
{
    public int WeaponID;
    public int maxBullets;
    public int reloadTime;
    public float betweenShotsTime;
    public bool Autofire;
    public int Bullets;
    public float damage = 10f;
    public float range = 100f;
    public GameObject Model;
    public AudioSource WeaponAudio;
    public AudioClip Shot;
    public AudioClip WeaponOn;

    [HideInInspector]
    public Image _image;
    private void Start()
    {
        _image = GetComponent<Image>();
        Bullets = maxBullets;
        DataHolder.Weapons.Add(this);
    }
    public void Change()
    {
        if (DataHolder.Weapons[DataHolder.ActivIndex].WeaponID == WeaponID)
        {
            DataHolder.Weapons[DataHolder.ActivIndex]._image.color = new Color(1f, 1f, 1f, 0.5f);
            DataHolder.Weapons[DataHolder.ActivIndex].Model.SetActive(false);
            DataHolder.WeaponOn = false;
            DataHolder.ActivIndex = 0;
        }
        else
        {
            DataHolder.WeaponOn = true;
            for (int i = 0; i < DataHolder.Weapons.Count; i++)
            {
                if (DataHolder.Weapons[i].WeaponID == WeaponID)
                {
                    DataHolder.Weapons[DataHolder.ActivIndex]._image.color = new Color(1f, 1f, 1f, 0.5f);
                    DataHolder.Weapons[DataHolder.ActivIndex].Model.SetActive(false);
                    DataHolder.ActivIndex = i;
                    WeaponAudio.PlayOneShot(WeaponOn);
                    DataHolder.Weapons[DataHolder.ActivIndex].Model.SetActive(true);
                    DataHolder.Weapons[DataHolder.ActivIndex]._image.color = new Color(1f, 1f, 1f, 1f);
                }
            }

        }
    }
}