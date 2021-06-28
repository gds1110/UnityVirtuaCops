using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController_Sally : MonoBehaviour
{
    
    [SerializeField]
    public GameObject[] hotdog;
    public GameObject[] life;
    public GameObject gameoverUI;

    public Gun_Sally gun;
    public PlayerController_Sally player;
    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.Find("Player").GetComponent<Gun_Sally>();
        player = GameObject.Find("Player").GetComponent<PlayerController_Sally>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            hotdog[i].SetActive(false);
        }

        for (int i = 0; i < gun.magAmmo; i++)
        {
            hotdog[i].SetActive(true);
        }

        for (int i = 0; i < 5; i++)
        {
            life[i].SetActive(false);
        }

        for (int i = 0; i < player.lifeCount; i++)
        {
            life[i].SetActive(true);
        }

        if(player.lifeCount == 0)
        {
            player.lifeCount = 0;
            gameoverUI.SetActive(true);
        }
        else
        {
            gameoverUI.SetActive(false);
        }
    }
}