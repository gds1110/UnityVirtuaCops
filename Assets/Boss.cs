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
    private void Awake()
    {
        gameObject.SetActive(false);
    }
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
           // SoundManager.instance.SFXPlay("ZombieWalk", clip);
        }

        if (animator.GetCurrentAnimatorStateInfo(1).IsName("Die"))
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
