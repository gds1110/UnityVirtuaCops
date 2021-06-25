using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBehavior : MonoBehaviour
{

    public bool loadScene;
    public bool cameraWayPoint;
    public string sceneToLoad;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag!="Player")
        {
            return;
        }
        //if(loadScene&&!string.IsNullOrEmpty(sceneToLoad))
        //{
        //    Application.LoadLevel(sceneToLoad);
        //}
        if(cameraWayPoint)
        {
            cameraWayPoint = false;
            CameraMovement.cameraMovement.NextWayPoint();
        }
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
