using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // 쫓아갈 대상
    public Transform target;
    // 좀비의 현위치
    public Transform myTransform;
    public Animator animator;
    public GameObject explosionEffect;
    private Rigidbody rigidbody;
    public bool isWalk;
    public bool isDeath;
    public float deathWaitingTime;
    public float dist;
    public bool isAppear;
    bool isTarget;
    public AudioClip clip;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        isWalk = false;
        isDeath = false;
        isAppear = true;
        isTarget = false;
        dist = 0f;
    }

    // Update is called once per frame
    void Update()
    {
   
        if(isAppear)
        {
            animator.SetTrigger("Appear");
            isAppear = false;
            SoundManager.instance.SFXPlay("Zombie_Aggresive", clip);
        }

        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Appear") && isAppear != true)
        {
            isTarget = true;
        }
            if (isTarget)
            {
                float prevY = transform.position.y;

                transform.LookAt(target);
                var pos = transform.position;
                pos.y = prevY;
                transform.position = pos;
            }
       
        dist = Vector3.Distance(target.position, myTransform.position);

        if (dist <= 5 )
        {
            animator.SetTrigger("Close with Player");
        }
   

        if (isWalk)
        {
            animator.SetBool("Walk", true);
            
        }
        else
            animator.SetBool("Walk", false);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            SoundManager.instance.SFXPlay("ZombieWalk", clip);
        }
        
        if (animator.GetCurrentAnimatorStateInfo(1).IsName("Die"))
        {
            Instantiate(explosionEffect, myTransform.position, myTransform.rotation);
            Destroy(gameObject,2);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && isDeath != true)
        {
            animator.SetTrigger("Death");
            SoundManager.instance.SFXPlay("ZombieDeath_1", clip);
            isDeath = true;
        }
    }
}
