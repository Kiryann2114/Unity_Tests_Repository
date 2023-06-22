using UnityEngine;
using UnityEngine.UI;

public class PlayerContorller : MonoBehaviour
{
    public Animator Animator;
    public FixedJoystick joystick;
    public Transform CameraTarget2;
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public Transform groundCheckerTransform;
    public LayerMask notPlayerMask;
    public float jumpForce = 2f;
    public float maxHp;
    public float HP;
    public Slider HelthBar;
    public GameObject Respawn;
    public AudioSource PlayerAudio;
    private Rigidbody _rb;
    private float h = 0;
    private float v = 0;
    private bool Death = false;

    private void Start()
    {
        HP = maxHp;
        HelthBar.maxValue = maxHp;
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Animator.SetBool("WeaponOn", DataHolder.WeaponOn);
        if (HP <= 0)
        {
            Death = true;
            Animator.SetBool("Death", true);
        }
        else
        {
            Death = false;
            Animator.SetBool("Death", false);
        }
        HelthBar.value = HP;
        h = joystick.Horizontal;
        v = joystick.Vertical;
    }

    private void FixedUpdate()
    {
        _rb.angularVelocity = Vector3.zero;
        Respawn.SetActive(Death);
        if (!Death)
        {
            CameraTarget2.position = new Vector3(transform.position.x, transform.position.y + 1.3f, transform.position.z);
            Vector3 dirVector = CameraTarget2.right * h + CameraTarget2.forward * v;
            if (DataHolder.WeaponOn)
            {
                transform.rotation = CameraTarget2.rotation;
            }
            else
            {
                if (dirVector.magnitude != 0)
                {
                    Animator.SetBool("Move", true);
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dirVector), rotationSpeed * Time.fixedDeltaTime);
                }
                else
                {
                    Animator.SetBool("Move", false);
                }
            }
            Vector3 moveDir = Vector3.ClampMagnitude(dirVector, 1) * moveSpeed;
            Animator.SetFloat("Magnitud", moveDir.magnitude);
            Animator.SetFloat("x", h);
            Animator.SetFloat("y", v);
            if (dirVector.magnitude != 0)
            {
                PlayerAudio.UnPause();
            }
            else
            {
                PlayerAudio.Pause();
            }
            _rb.velocity = new Vector3(moveDir.x, _rb.velocity.y, moveDir.z);
        }
    }

    public void Jump()
    {
        if (Physics.Raycast(groundCheckerTransform.position, Vector3.down, 0.2f, notPlayerMask))
        {
            Animator.SetTrigger("Jump");
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}