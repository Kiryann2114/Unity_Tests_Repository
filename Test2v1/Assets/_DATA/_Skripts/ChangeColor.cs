using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColor : MonoBehaviour , IPointerClickHandler
{
    public Material material;
    public void OnPointerClick(PointerEventData eventData)
    {
        material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 0.7f);
    }
}