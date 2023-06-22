using UnityEngine;
using UnityEngine.UI;

public class CarCntrol : MonoBehaviour
{
    [SerializeField] private Transform _transformFL;
    [SerializeField] private Transform _transformFR;
    [SerializeField] private Transform _transformBL;
    [SerializeField] private Transform _transformBR;

    [SerializeField] private WheelCollider _colliderFL;
    [SerializeField] private WheelCollider _colliderFR;
    [SerializeField] private WheelCollider _colliderBL;
    [SerializeField] private WheelCollider _colliderBR;

    [SerializeField] private Text speed;

    [SerializeField] private float _dragCoof = 0.35f;
    public enum _privod
    {
        Pered,
        Zad,
        Poln
    }
    public _privod Privod;
    [SerializeField] private float _force;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _break;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        DataHolder.Speed = _rb.velocity.magnitude * 3.6f;
        speed.text = (_rb.velocity.magnitude * 3.6f).ToString("0") + " km/h";
    }

    private void FixedUpdate()
    {
        switch (Privod)
        {
            case _privod.Pered:
                _colliderFL.motorTorque = DataHolder.Vertical * _force;
                _colliderFR.motorTorque = DataHolder.Vertical * _force;
                break;
            case _privod.Zad:
                _colliderBL.motorTorque = DataHolder.Vertical * _force;
                _colliderBR.motorTorque = DataHolder.Vertical * _force;
                break;
            case _privod.Poln:
                _colliderFL.motorTorque = DataHolder.Vertical * _force;
                _colliderFR.motorTorque = DataHolder.Vertical * _force;
                _colliderBL.motorTorque = DataHolder.Vertical * _force;
                _colliderBR.motorTorque = DataHolder.Vertical * _force;
                break;
        }

        _colliderFL.motorTorque = _colliderFL.motorTorque * _dragCoof;
        _colliderFR.motorTorque = _colliderFR.motorTorque * _dragCoof;
        _colliderBL.motorTorque = _colliderFR.motorTorque * _dragCoof;
        _colliderBR.motorTorque = _colliderFR.motorTorque * _dragCoof;


        if (DataHolder.Break)
        {
            _colliderFL.brakeTorque = _break;
            _colliderFR.brakeTorque = _break;
            _colliderBL.brakeTorque = _break;
            _colliderBR.brakeTorque = _break;
        }
        else
        {
            _colliderFL.brakeTorque = 0f;
            _colliderFR.brakeTorque = 0f;
            _colliderBL.brakeTorque = 0f;
            _colliderBR.brakeTorque = 0f;
        }

        _colliderFL.steerAngle = _maxAngle * DataHolder.Horisontal;
        _colliderFR.steerAngle = _maxAngle * DataHolder.Horisontal;

        RotateWheel(_colliderFL, _transformFL);
        RotateWheel(_colliderFR, _transformFR);
        RotateWheel(_colliderBL, _transformBL);
        RotateWheel(_colliderBR, _transformBR);
    }

    private void RotateWheel(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        transform.rotation = rotation;
        transform.position = position;
    }
}
