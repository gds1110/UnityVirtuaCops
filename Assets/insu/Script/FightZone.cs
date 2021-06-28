using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightZone : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Starter;
    public Transform nodeLocation;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Enemy")==null)
        {
            Instantiate(Starter, nodeLocation.position, nodeLocation.rotation);
            Destroy(gameObject);
        }
    }
}
