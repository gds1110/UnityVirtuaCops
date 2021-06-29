using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Sally : MonoBehaviour
{
    // �Ѿ�
    bool isFire;    // �Ѿ��� ���ư��� �����ߴٴ� ����
    Vector3 direction;  // �Ѿ��� ���ư��� ����
    [SerializeField]
    float speed = 10;    // �Ѿ��� ���ư��� �ӵ�

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
