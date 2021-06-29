using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


enum BGMState
{
    Opening,Enemy,Boss, Ending_Result, Win, Lose,None
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource bgm;
    public AudioClip[] bgmList;
    BGMState bgmState;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
           
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SFXPlay(string sfxName,AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.clip = clip;
        audiosource.Play();

        Destroy(go, clip.length);
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bgmState = BGMState.Opening;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            bgmState = BGMState.Enemy;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            bgmState = BGMState.Boss;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            bgmState = BGMState.Ending_Result;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {

            bgmState = BGMState.Win;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {

            bgmState = BGMState.Lose;
        }

        switch (bgmState)
        {
            case BGMState.Opening:
                BGMPlay(bgmList[0]);
                bgmState = BGMState.None;
                break;
            case BGMState.Enemy:
                BGMPlay(bgmList[1]);
                bgmState = BGMState.None;
                break;
            case BGMState.Boss:
                BGMPlay(bgmList[2]);
                bgmState = BGMState.None;
                break;
            case BGMState.Ending_Result:
                BGMPlay(bgmList[3]);
                bgmState = BGMState.None;
                break;
            case BGMState.Win:
                BGMPlay(bgmList[4],false);
                bgmState = BGMState.None;
                break;
            case BGMState.Lose:
                BGMPlay(bgmList[5],false);
                bgmState = BGMState.None;
                break;
            case BGMState.None:
                break;
        }
    }

    public void BGMPlay(AudioClip clip, bool isLoop = true)
    {
        bgm.clip = clip;
        bgm.loop = isLoop;
        bgm.volume = 0.1f;
        bgm.Play();
    }
}
