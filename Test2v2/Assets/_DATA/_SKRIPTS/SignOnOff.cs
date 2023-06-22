using UnityEngine;

public class SignOnOff : MonoBehaviour
{
    public AudioSource SIG;
    public AudioSource DVIG;
    public AudioSource HOL;
    public AudioSource P;

    private void Update()
    {
        if (DataHolder.SIGN)
        {
            SIG.enabled = true;
        }
        else
        {
            SIG.enabled = false;
        }

        if (DataHolder.Vertical != 0)
        {
            HOL.enabled = false;
            DVIG.enabled = true;
        }
        else
        {
            DVIG.enabled = false;
            HOL.enabled = true;
        }

        if (DataHolder.Break)
        {
            if (DataHolder.Speed > 40)
            {
                P.enabled = true;
            }
        }
        if (DataHolder.Speed < 15)
        {
            P.enabled = false;
        }
    }
}
