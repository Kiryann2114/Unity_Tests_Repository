using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.tag == "ButF")
        {
            if (DataHolder.Vertical != -1)
            {
                DataHolder.Vertical = 1;
            }
        }
        if (this.tag == "ButB")
        {
            if (DataHolder.Vertical != 1)
            {
                DataHolder.Vertical = -1;
            }
        }
        if (this.tag == "ButL")
        {
            if (DataHolder.Horisontal != 1)
            {
                DataHolder.Horisontal = -1;
            }
        }
        if (this.tag == "ButR")
        {
            if (DataHolder.Horisontal != -1)
            {
                DataHolder.Horisontal = 1;
            }
        }
        if (this.tag == "ButS")
        {
            DataHolder.SIGN = true;
        }
        if (this.tag == "ButP")
        {
            DataHolder.Break = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (this.tag == "ButF")
        {
            DataHolder.Vertical = 0;
        }
        if (this.tag == "ButB")
        {
            DataHolder.Vertical = 0;
        }
        if (this.tag == "ButL")
        {
            DataHolder.Horisontal = 0;
        }
        if (this.tag == "ButR")
        {
            DataHolder.Horisontal = 0;
        }
        if (this.tag == "ButS")
        {
            DataHolder.SIGN = false;
        }
        if (this.tag == "ButP")
        {
            DataHolder.Break = false;
        }
    }
}
