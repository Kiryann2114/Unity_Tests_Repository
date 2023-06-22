using UnityEngine;
using UnityEngine.UI;

public class FireButtomOn : MonoBehaviour
{
    public GameObject FireButton;
    public GameObject ReloadButton;
    public GameObject CountBullets;
    private void Update()
    {
        FireButton.SetActive(DataHolder.WeaponOn);
        ReloadButton.SetActive(DataHolder.WeaponOn);
        CountBullets.SetActive(DataHolder.WeaponOn);
        if (DataHolder.WeaponOn)
        {
            CountBullets.GetComponent<Text>().text = DataHolder.Weapons[DataHolder.ActivIndex].Bullets.ToString();
        }
    }
}
