using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Sally : MonoBehaviour
{
    //RaycastHit hit;             // �浹 ����

    public GameObject bulletPrefab;

    public GameObject firePos;
    Gun_Sally gun;
    //public Camera camera;

    private void Start()
    {
        gun = GetComponent<Gun_Sally>();
        //camera = Camera.main; // ī�޶��� ������ �����´�
        //camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���� �߻�
        {
            gun.Fire();
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // ȭ����� ���콺 ��ǥ ��������

            ////Debug.DrawRay(transform.position, -transform.right * maxDistance, Color.blue, 0.3f);   // ���̸� ������ ���� ���� �α� ���� �ڵ�

            //// ����ĳ��Ʈ ����
            //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            //{
            //    Debug.Log(hit.collider.gameObject.name);
            //    //hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;  // �浹 ������ �Ѵٸ� ���̿� �浹�� ��ü�� ���������� ����
            //}
            ////Vector3 firePos = transform.position + transform.forward + new Vector3(0f, 0.5f, 0f);

            //Vector3 mousPos = Input.mousePosition;
            //var bullet = Instantiate(bulletPrefab, firePos.transform.position, Quaternion.identity).GetComponent<Bullet_Sally>();
            //bullet.transform.LookAt(Camera.main.ScreenToWorldPoint(new Vector3(mousPos.x, mousPos.y, 1)));
            ////bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
            //bullet.Fire(transform.forward);
        }
        //Debug.Log(Input.mousePosition);
        
        if(Input.GetMouseButtonDown(1))
        {
            gun.Reload();
        }
    }
}
