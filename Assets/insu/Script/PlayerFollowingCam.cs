using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowingCam : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cam.GetComponent<Transform>().position;
    }
}