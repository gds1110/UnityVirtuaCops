using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public GameObject exlposionEffect;
    float countdown;
    bool hasExploded = false;

    class Hp
    {
        private int _data;
        public int data
        {
            get { return _data; }    // _data ��ȯ
            set { _data = value; }   // value Ű���� ���
        }
    }


    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(exlposionEffect, transform.position, transform.rotation);
        // ����Ʈ 
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in collidersToDestroy)
        {
            //Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            //if(rb != null)
            //{
            //    rb.AddExplosionForce(force, transform.position, radius);
            //}

            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if (dest != null)
            {
                dest.Destroy();
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
        //foreach (Collider nearbyObject in collidersToMove)
        //{
        //    Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
        //    if (rb != null)
        //    {
        //        rb.AddExplosionForce(force, transform.position, radius);
        //    }
        //}

        // ����
        Destroy(gameObject);
        Debug.Log("BOOM!");
    }
}
