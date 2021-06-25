using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public static CharMovement charMovenet;

    void Ascend()
    {
        bool pastTopScreenEdge = Camera.main.WorldToScreenPoint(transform.position).y > Screen.height;

        transform.Translate(0, pastTopScreenEdge ? 0 : .5f, 0);
    }

    void BankLeft()
    {
        bool pastLeftScreenEdge = Camera.main.WorldToScreenPoint(transform.position).x <= 0;

        transform.Translate(pastLeftScreenEdge ? 0 : -.5f, 0, 0);
    }
      void BankRight()
    {
        bool pastRightScreenEdge = Camera.main.WorldToScreenPoint(transform.position).x >= 0;

        transform.Translate(pastRightScreenEdge ? 0 : .5f, 0, 0);
    }
    void Dive()
    {
        bool pastBottomScreenEdge = Camera.main.WorldToScreenPoint(transform.position).y <= 0;

        transform.Translate(0, pastBottomScreenEdge ? 0 : -.5f, 0);
    }

    private void FixedUpdate()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;

        //키에 따라 방향전환인데 여기선 안쓸거임어차피

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
