using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Sally : MonoBehaviour
{
    public int lifeCount;
    public int lifeMaxCount = 5;
    public GameObject Cam;
    private void OnEnable()
    {
        lifeCount = lifeMaxCount;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Cam.transform.rotation;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            lifeCount--;
            
            if(lifeCount <= 0)
            {
                lifeCount = 0;
            }
        }
    }
}