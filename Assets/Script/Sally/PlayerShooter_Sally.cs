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
        // 슈터가 활성화될 때 총도 함께 활성화
        hotdog.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        // 슈터가 비활성화될 때 총도 함께 비활성화
        hotdog.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 입력을 감지하고 총 발사하거나 재장전
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
            // UI 매니저의 탄약 텍스트에 탄창의 탄약과 남은 전체 탄약을 표시
            UIManager_Sally.instance.UpdateAmmoText(hotdog.magAmmo, hotdog.ammoRemain);
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {

    }
}
