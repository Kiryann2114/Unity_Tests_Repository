using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Transform transform;
    void Start()
    {
        transform = GetComponent<Transform>();
    }
    void Update()
    {
        transform.Rotate(0, -10 * Time.deltaTime, 0, Space.Self);
    }
}