using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Transform MainCamera;
    private Image Cross;
    private bool weap = DataHolder.WeaponOn;
    private void Start()
    {
        Cross = GetComponent<Image>();
    }
    void Update()
    {
        if (DataHolder.WeaponOn != weap)
        {
            if (DataHolder.WeaponOn)
            {
                Cross.enabled = true;
                MainCamera.position += new Vector3(0.5f, 0, 0);
            }
            else
            {
                Cross.enabled = false;
                MainCamera.position -= new Vector3(0.5f, 0, 0);
            }
        }
        weap = DataHolder.WeaponOn;
    }
}