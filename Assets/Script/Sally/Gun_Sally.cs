using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Sally : MonoBehaviour
{
    // ���� ���¸� ǥ���ϴµ� ����� Ÿ���� �����Ѵ�
    public enum State
    {
        Ready,  // �߻� �غ��
        Empty,  // źâ�� ��
        Reloading   // ������ ��
    }

    public State state { get; private set; }  // ���� ���� ����

    public Transform fireTransform; // �Ѿ��� �߻�� ��ġ

    public float damage = 25; // ���ݷ�
    private float fireDistance = 50f; // �����Ÿ�

    public int ammoRemain = 100; // ���� ��ü ź��
    public int magCapacity = 6;  // źâ �뷮
    public int magAmmo; // ���� źâ�� �����ִ� ź��

    public float timeBetFire = 0.12f; // �Ѿ� �߻� ����
    public float reloadTime = 1.0f; // ������ �ҿ� �ð�
    private float lastFireTime; // ���� ���������� �߻��� ����

    public GameObject bulletPrefab;
    public GameObject firePos;

    private void OnEnable()
    {
        // �� ���� �ʱ�ȭ
        magAmmo = magCapacity;
        state = State.Ready;
        lastFireTime = 0;
    }

    // �߻� �õ�
    public void Fire()
    {
        if (state == State.Ready && Time.time >= lastFireTime + timeBetFire)
        {
            lastFireTime = Time.time;
            Shot();
        }
    }

    // ���� �߻� ó��
    private void Shot()
    {
        // �浹 ����
        RaycastHit hit; 

        // ȭ����� ���콺 ��ǥ ��������
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // ����ĳ��Ʈ ����
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.collider.gameObject.name);
        }

        Vector3 mousPos = Input.mousePosition;

        var bullet = Instantiate(bulletPrefab, firePos.transform.position, Quaternion.identity).GetComponent<Bullet_Sally>();
        
        bullet.transform.LookAt(Camera.main.ScreenToWorldPoint(new Vector3(mousPos.x, mousPos.y, 1)));
        
        bullet.Fire(transform.forward);
       
        magAmmo--;
        if (magAmmo <= 0)
        {
            state = State.Empty;
        }
    }

    //���̸� ������ ���� ���� �α� ���� �ڵ�
    //Debug.DrawRay(transform.position, -transform.right * fireDistance, Color.blue, 0.3f); 
    //hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;  // �浹 ������ �Ѵٸ� ���̿� �浹�� ��ü�� ���������� ����

    // ������ �õ�
    public bool Reload()
    {
        if (state == State.Reloading || ammoRemain <=0 || magAmmo >= magCapacity)
        {
            return false;
        }

        StartCoroutine(ReloadRoutine());
        return true;
    }

    // ���� ������ ó���� ����
    private IEnumerator ReloadRoutine()
    {
        // ���� ���¸� ������ �� ���·� ��ȯ
        state = State.Reloading;

        // ������ �ҿ� �ð� ��ŭ ó���� ����
        yield return new WaitForSeconds(reloadTime);

        int ammoToFill = magCapacity - magAmmo;

        if(ammoRemain < ammoToFill)
        {
            ammoToFill = ammoRemain;
        }

        magAmmo += ammoToFill;
        ammoRemain -= ammoToFill;

        // ���� ���� ���¸� �߻� �غ�� ���·� ����
        state = State.Ready;
    }
}
