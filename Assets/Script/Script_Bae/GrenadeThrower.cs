using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 10f;
    public GameObject grenadePrefab;
    public Animator animator;
    int throwCount = 0;
    int maxThrowCount = 1;


    private void Start()
    {
   
        animator = GetComponent<Animator>();
        if (gameObject.CompareTag("Boss"))
        {
            grenadePrefab.transform.localScale = new Vector3(10f,10f,10f);
        }
    }

    void Update()
    {

        //if (animator.GetCurrentAnimatorStateInfo(0).IsName("Throw") &&
        //    animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f &&
        //    animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.6f &&
        //    throwCount < maxThrowCount)
        //{
        //    ThrowGrenade();
  
        //    // 다음 상태로
        //    animator.SetTrigger("Throw");
        //    throwCount++;
        //}
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Throw") &&
          throwCount < maxThrowCount)
        {
            ThrowGrenade();

            // 다음 상태로
            animator.SetTrigger("Throw");
            throwCount++;
        }

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Throw"))
        {
            throwCount = 0;
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
   
}
