using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject grenadePrefab;
    public Animator animator;

   private float coolTime;
    private float timer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        coolTime = 4f;
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= coolTime)
        {
            ThrowGrenade();
            // 다음 상태로
            animator.SetTrigger("Threw");
            timer = 0;
        }
        //if (!PlayerMovement.instance.anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        //{
        //    PlayerMovement.instance.anim.SetBool("Attack", false);
        //    PlayerMovement.instance.anim.SetBool("Walk", false);
        //    PlayerMovement.instance.anim.SetBool("Idle", true);
        //}

    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
   
}
