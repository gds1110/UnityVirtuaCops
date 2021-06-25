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
    private Rigidbody rigidbody;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float prevY = transform.position.y;
        
        transform.LookAt(target);
        var pos = transform.position;
        pos.y = prevY;
        transform.position = pos;

        float dist = Vector3.Distance(target.position, myTransform.position);

        if (dist <= 5 )
        {
            animator.SetTrigger("Close with Player");
        }

    }
}
