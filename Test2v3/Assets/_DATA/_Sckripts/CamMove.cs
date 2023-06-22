using UnityEngine;
using UnityEngine.EventSystems;

public class CamMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform CameraTarget;
    public Transform CameraTarget2;
    public float sensitivity = 0.1f;
    public float minX = -20f;
    public float maxX = 45f;
    private float rotationY = 0.0f;
    private float rotationX = 0.0f;
    private Vector2 lastTouchPosition;
    private bool pressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == gameObject)
        {
            pressed = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    void Update()
    {
        CameraTarget.position = CameraTarget2.position;
        if (pressed)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 deltaPosition = touch.position - lastTouchPosition;

                rotationY += deltaPosition.x * sensitivity * Time.deltaTime;
                rotationX += - deltaPosition.y * sensitivity * Time.deltaTime;
                rotationX = Mathf.Clamp(rotationX, minX, maxX);

                CameraTarget.localEulerAngles = new Vector3(rotationX, rotationY, 0);
                CameraTarget2.localEulerAngles = new Vector3(0, rotationY, 0);

                lastTouchPosition = touch.position;
            }
        }
    }
}