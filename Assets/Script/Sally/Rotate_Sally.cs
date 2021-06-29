using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Sally : MonoBehaviour
{
    public float speed = 10;
    public float guiSpeed = 1;

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
        //if(Input.GetKey("t"))
        //{

        //}
        //else
        //{
        //    rotateV = Vector3.zero;
        //}
         rotateV = new Vector3(0, 0, 1);

        //position.x -= 1 * Time.deltaTime;

        //transform.position = position;
        transform.Rotate(rotateV * speed);
    }

    private void OnGUI()
    {
        rotateV = new Vector3(0, 0, 1);
        transform.Rotate(rotateV * guiSpeed);
    }
}
