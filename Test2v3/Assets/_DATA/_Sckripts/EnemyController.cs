using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Animator Animator;
    public float Speed;
    public float maxHP;
    public float HP;
    public float Damage;
    public float timeBetweenAttacks;
    public float TimeRespawn;
    public bool Angry;
    public Slider helthBar;
    public AudioSource EnamyAudio;

    private LookAtPlayer look;
    private Rigidbody rb;
    private Collider player;
    private bool Stay;
    private bool FlagResp = true;
    void Start()
    {
        helthBar.maxValue = maxHP;
        look = GetComponent<LookAtPlayer>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.angularVelocity = Vector3.zero;
        helthBar.value = HP;
        if (HP <= 0)
        {
            if (FlagResp)
            {
                FlagResp = false;
                Animator.SetBool("Death", true);
                EnamyAudio.Pause();
                look.enabled = false;
                StartCoroutine(waiterRespawn());
            }
        }
        else
        {
            EnamyAudio.UnPause();
            Animator.SetBool("Death", false);
            if (Angry)
            {
                look.enabled = true;
                Animator.SetBool("Move",true);
                transform.position += transform.forward * Time.deltaTime * Speed;
            }
            else
            {
                Animator.SetBool("Move", false);
            }
        }
    }
    IEnumerator waiterRespawn()
    {
        yield return new WaitForSeconds(TimeRespawn);
        HP = maxHP;
        FlagResp = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (Angry)
        {
            if (other.tag == "Player")
            {
                Stay = true;
                player = other;
                StartCoroutine(waiter());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Stay = false;
    }
    IEnumerator waiter()
    {
        while (Stay && HP > 0)
        {
            Animator.SetTrigger("Punch");
            player.GetComponent<PlayerContorller>().HP -= Damage;
            yield return new WaitForSeconds(timeBetweenAttacks);
        }
    }
}