using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Sally : MonoBehaviour
{
    //RaycastHit hit;             // 충돌 감지

    public GameObject bulletPrefab;

    public GameObject firePos;
    Gun_Sally gun;
    //public Camera camera;

    private void Start()
    {
        gun = GetComponent<Gun_Sally>();
        //camera = Camera.main; // 카메라의 메인을 가져온다
        //camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 레이 발사
        {
            gun.Fire();
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // 화면상의 마우스 좌표 가져오기

            ////Debug.DrawRay(transform.position, -transform.right * maxDistance, Color.blue, 0.3f);   // 레이를 씬에서 보기 위해 로그 찍어보는 코드

            //// 레이캐스트 과정
            //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            //{
            //    Debug.Log(hit.collider.gameObject.name);
            //    //hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;  // 충돌 감지를 한다면 레이와 충돌한 물체는 빨간색으로 변함
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
