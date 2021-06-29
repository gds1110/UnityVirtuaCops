using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Sally : MonoBehaviour
{
    // 총알
    bool isFire;    // 총알이 날아가기 시작했다는 변수
    Vector3 direction;  // 총알이 날아가는 방향
    [SerializeField]
    float speed = 10;    // 총알이 날아가는 속도

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isFire)
        {
            
            transform.Translate(direction * Time.deltaTime * speed);
            
        }
    }

    public void Fire(Vector3 dir)
    {
        direction = dir;
        isFire = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Bullet_Sally>() == null)
        {
            Destroy(gameObject);
        }
    }
}
