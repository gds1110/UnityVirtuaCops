using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // 쫓아갈 대상
    public Transform target;
    // 좀비의 현위치
    public Transform myTransform;
    public Animator animator;
    public GameObject explosionEffect;
    private Rigidbody rigidbody;
    public AudioClip clip;
    public int hp;

    public bool isDeath;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        hp = 100;
        isDeath = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (animator.GetCurrentAnimatorStateInfo(0).IsName("RunLeft"))
        {
            transform.Translate(-1 * Time.deltaTime, 0, 0);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("RunRight"))
        {
            transform.Translate(1 * Time.deltaTime, 0, 0);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("BigAttackJump") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.8f)
        {
            transform.Translate(0, 8 * Time.deltaTime, 1 * Time.deltaTime);
            rigidbody.useGravity = false;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("BigAttack") &&
         animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.8f)
        {
            transform.Translate(0, -8 * Time.deltaTime,0);
            rigidbody.useGravity = true;
        }



        if (animator.GetCurrentAnimatorStateInfo(0).IsName("KnockBack"))
        {
            transform.Translate(0, 0, -1 * Time.deltaTime);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            Instantiate(explosionEffect, myTransform.position, myTransform.rotation);
            Destroy(gameObject, 2);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hp <= 0 && isDeath != true)
        {
            animator.SetTrigger("Death");
            SoundManager.instance.SFXPlay("ZombieDeath_1", clip);
            isDeath = true;
        }
    }
}
