using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject target;
    
    public Transform myTransform;
    public Animator animator;
    public GameObject explosionEffect;
    public GameObject appearEffect;
    private Rigidbody rigidbody;
    public bool isWalk;
    public bool isDeath;
    public float dist;
    bool isTarget;
    bool isAppear;
    private void Awake()
    {
        target = GameObject.FindWithTag("Player");
        
    }
    public AudioClip clip;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        //isWalk = false;
        isWalk = false;
        isDeath = false;
        isTarget = false;
        dist = 0f;
        isAppear = true;
       
    }

    // Update is called once per frame
    void Update()
    {

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Appear") && isAppear == true)
        {
            var varEffect=Instantiate(appearEffect, myTransform.position, myTransform.rotation);
            Destroy(varEffect,1f);
           
            isAppear = false;
        }
        
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Appear") && isTarget != true)
        {
            isTarget = true;

        }
        if (isTarget)
        {
            float prevY = transform.position.y;

            transform.LookAt(target.transform);
            var pos = transform.position;
            pos.y = prevY;
            transform.position = pos;
        }
       
        dist = Vector3.Distance(target.transform.position, myTransform.position);

        if (dist <= 18 )
        {
            animator.SetTrigger("Close with Player");
        }
   

        if (isWalk)
        {
            animator.SetBool("Walk", true);
            
        }
        else
            animator.SetBool("Walk", false);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            Instantiate(explosionEffect, myTransform.position, myTransform.rotation);
            Destroy(gameObject,2);
        }
        //if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        //{
        //    SoundManager.instance.SFXPlay("ZombieWalk", clip);
        //}
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Bullet") && isDeath != true)
        {
            animator.SetTrigger("Death");
            //SoundManager.instance.SFXPlay("ZombieDeath_1", clip);
            isDeath = true;
            StartCoroutine(DeathTime());
        }
    }
    IEnumerator DeathTime()
    {

        yield return new WaitForSeconds(1.0f); 
        gameObject.GetComponentInParent<EnemySpawn_insu>().deathCount++;
        Destroy(gameObject);
    }
}
