using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 10;
    public Vector3 rotateV;

    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("t"))
        {
            rotateV = new Vector3(0, 0, 1);

            position.x -= 1 * Time.deltaTime;

            transform.position = position;
        }
        else
        {
            rotateV = Vector3.zero;
        }

        transform.Rotate(rotateV * speed);
    }
}
