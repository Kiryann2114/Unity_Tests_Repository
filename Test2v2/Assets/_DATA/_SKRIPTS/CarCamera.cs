using UnityEngine;

public class CarCamera : MonoBehaviour
{
    public Transform car;
    public float distance = 10.0f;
    public float height = 5.0f;
    public float rotationDamping = 3.0f;
    public float heightDamping = 2.0f;

    private void FixedUpdate()
    {
        if (!car)
            return;

        float wantedRotationAngle = car.eulerAngles.y;
        float wantedHeight = car.position.y + height;
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        Vector3 pos = car.position - currentRotation * Vector3.forward * distance;
        pos.y = currentHeight;

        transform.position = pos;
        transform.LookAt(car);
    }
}
