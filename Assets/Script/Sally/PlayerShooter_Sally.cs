using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter_Sally : MonoBehaviour
{
    public Gun_Sally hotdog;
    public Transform hotdogPivot;
   // public Transform rightHandMount;

    private PlayerInput playerInput;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // ���Ͱ� Ȱ��ȭ�� �� �ѵ� �Բ� Ȱ��ȭ
        hotdog.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        // ���Ͱ� ��Ȱ��ȭ�� �� �ѵ� �Բ� ��Ȱ��ȭ
        hotdog.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // �Է��� �����ϰ� �� �߻��ϰų� ������
        if (playerInput.fire)
        {
            hotdog.Fire();
        }
        else if (playerInput.reload)
        {
            playerAnimator.SetTrigger("Reload");
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        if(hotdog != null && UIManager_Sally.instance != null)
        {
            // UI �Ŵ����� ź�� �ؽ�Ʈ�� źâ�� ź��� ���� ��ü ź���� ǥ��
            UIManager_Sally.instance.UpdateAmmoText(hotdog.magAmmo, hotdog.ammoRemain);
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {

    }
}
