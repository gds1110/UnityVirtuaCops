using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Sally : MonoBehaviour
{
    // 총의 상태를 표현하는데 사용할 타입을 선언한다
    public enum State
    {
        Ready,  // 발사 준비됨
        Empty,  // 탄창이 빔
        Reloading   // 재장전 중
    }

    public State state { get; private set; }  // 현재 총의 상태

    public Transform fireTransform; // 총알이 발사될 위치

    public float damage = 25; // 공격력
    private float fireDistance = 50f; // 사정거리

    public int ammoRemain = 10000; // 남은 전체 탄약
    public int magCapacity = 6;  // 탄창 용량
    public int magAmmo; // 현재 탄창에 남아있는 탄약

    public float timeBetFire = 0.12f; // 총알 발사 간격
    public float reloadTime = 0.5f; // 재장전 소요 시간
    private float lastFireTime; // 총을 마지막으로 발사한 시점

    public GameObject bulletPrefab;
    public GameObject firePos;
    public AudioClip clip;

    private void OnEnable()
    {
        // 총 상태 초기화
        magAmmo = magCapacity;
        state = State.Ready;
        lastFireTime = 0;
    }
    public void Awake()
    {        // 총 상태 초기화
        magAmmo = magCapacity;
        state = State.Ready;
        lastFireTime = 0;

    }
    // 발사 시도
    public void Fire()
    {
        if (state == State.Ready && Time.time >= lastFireTime + timeBetFire)
        {
            lastFireTime = Time.time;
            Shot();
               
    SoundManager.instance.SFXPlay("ThrowSound(Woosh)", clip);
        }
    }

    // 실제 발사 처리
    private void Shot()
    {
        RaycastHit hit;
        Vector3 hitPosition = Vector3.zero;

        //Debug.DrawRay(transform.position, transform.right * fireDistance, Color.blue, 0.3f);

        //if (Physics.Raycast(fireTransform.position, fireTransform.right, out hit, fireDistance))
        //{
        //    IDamageable target = hit.collider.GetComponent<IDamageable>();

        //    if (target != null)
        //    {
        //        target.OnDamage(damage, hit.point, hit.normal);
        //    }

        //    hitPosition = hit.point;
        //}
        //else
        //{
        //    hitPosition = fireTransform.position + fireTransform.forward * fireDistance;
        //}

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // 화면상의 마우스 좌표 가져오기

        //Debug.DrawRay(transform.position, -transform.right * maxDistance, Color.blue, 0.3f);   // 레이를 씬에서 보기 위해 로그 찍어보는 코드

        // 레이캐스트 과정
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.collider.gameObject.name);
            SoundManager.instance.SFXPlay("Splat_1", clip);
            //hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;  // 충돌 감지를 한다면 레이와 충돌한 물체는 빨간색으로 변함
        }
        //Vector3 firePos = transform.position + transform.forward + new Vector3(0f, 0.5f, 0f);

        Vector3 mousPos = Input.mousePosition;
        var bullet = Instantiate(bulletPrefab, firePos.transform.position, Quaternion.identity).GetComponent<Bullet_Sally>();
        bullet.transform.LookAt(Camera.main.ScreenToWorldPoint(new Vector3(mousPos.x, mousPos.y, 1)));
        //bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
        bullet.Fire(transform.forward);
       
        magAmmo--;
        if (magAmmo <= 0)
        {
            state = State.Empty;
        }
    }

    // 재장전 시도
    public bool Reload()
    {
        if (state == State.Reloading || ammoRemain <=0 || magAmmo >= magCapacity)
        {
            return false;
        }

        StartCoroutine(ReloadRoutine());
        return true;
    }

    // 실제 재장전 처리를 진행
    private IEnumerator ReloadRoutine()
    {
        // 현재 상태를 재장전 중 상태로 전환
        state = State.Reloading;

        // 재장전 소요 시간 만큼 처리를 쉬기
        yield return new WaitForSeconds(reloadTime);

        int ammoToFill = magCapacity - magAmmo;

        if(ammoRemain < ammoToFill)
        {
            ammoToFill = ammoRemain;
        }

        magAmmo += ammoToFill;
        ammoRemain -= ammoToFill;

        // 총의 현재 상태를 발사 준비된 상태로 변경
        state = State.Ready;
    }
}
