using UnityEngine;

public class LightONOFFScr : MonoBehaviour
{
    public Light LightR;
    public Light LightL;
    public void LightOnOff()
    {
        LightL.enabled = !LightL.enabled;
        LightR.enabled = !LightR.enabled;
    }
}