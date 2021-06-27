using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public static CameraMovement cameraMovement = null;

    public List<Transform> wayPoints;
    public float speed;

    public Vector3 GetMovementVector()
    {
        Vector3 moveVector = Vector3.zero;
        if(wayPoints.Count!=0)
        {
            moveVector = Vector3.Normalize(transform.position - wayPoints[0].transform.position);
            return moveVector;
        }
       else
        {
            return Vector3.zero;
        }
    }

    public void NextWayPoint()
    {
        wayPoints.RemoveAt(0);
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        bool repeat = true;
        while (repeat && wayPoints.Count !=0)
        {
            Quaternion originalRotation = transform.rotation;
            Vector3 targetDirection = wayPoints[0].position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, Time.deltaTime / 2, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
           // transform.LookAt(newDirection);
            if(originalRotation !=transform.rotation)
            {
                yield return new WaitForEndOfFrame();
            }
            else
            {
                repeat = false;
            }
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = this;

        wayPoints[0].LookAt(transform.position);
        for (int x = 1; x < wayPoints.Count; x++)
        {
            wayPoints[x].LookAt(wayPoints[x - 1].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(wayPoints.Count!=0)
        {
            float step = speed * Time.deltaTime;
            Vector3 moveVector = Vector3.Normalize(transform.position - wayPoints[0].transform.position);
            transform.position = transform.position - moveVector * step;
        }
    }
}
