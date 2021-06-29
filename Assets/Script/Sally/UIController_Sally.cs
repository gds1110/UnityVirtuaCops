using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController_Sally : MonoBehaviour
{
    Gun_Sally gun;
    PlayerController_Sally player;

    public GameObject[] hotdog;
    public GameObject[] life;
    public GameObject gameoverUI;
    public GameObject gameWinUI;
    public int SetWidth;
    public int SetHeight;
    public bool fullscreen;
    public GameObject PlayerObject;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        //Screen.SetResolution(Screen.width, Screen.width * SetWidth / SetHeight, fullscreen);
        //gun = GameObject.Find("Player").GetComponent<Gun_Sally>();
        //player = GameObject.Find("Player").GetComponent<PlayerController_Sally>();
        gun = PlayerObject.GetComponent<Gun_Sally>();
        player = PlayerObject.GetComponent<PlayerController_Sally>();
       
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
        if (boss != null)
        {
            if (boss.GetComponent<Boss>().isDeath == true)
            {
                gameWinUI.SetActive(true);
            }
            else
            {
                gameWinUI.SetActive(false);
            }
        }
    }
}