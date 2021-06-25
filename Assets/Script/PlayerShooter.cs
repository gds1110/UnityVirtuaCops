using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Weapon hotdog;
    public Transform hotdogPivot;
    public Transform rightHandMount;

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
        hotdog.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        hotdog.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateUI()
    {
        if(hotdog != null &&  UIManager.instance != null)
        {
            UIManager.instance.UpdateAmmoText(hotdog.magAmmo, hotdog.ammoRemain);
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {

    }
}
