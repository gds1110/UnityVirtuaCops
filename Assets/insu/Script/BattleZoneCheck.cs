using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
//using Cinemachine; 

public class BattleZoneCheck : MonoBehaviour
{
    [SerializeField] 
    public PlayableDirector playableDirector;
    public TimelineAsset timeline;
  //  public CinemachineCameraOffset chnemaCamera;
    public bool Checking = false;
    public EnemySpawn_insu Espawn;
    // Start is called before the first frame update
    //  public ICinemachineCamera cinemachineCamera;
   
    //public CinemachineVirtualCamera cv;
    float paths;
    public GameObject target;
    
    void Start()
    {
        playableDirector.GetComponent<PlayableDirector>();
        //Espawn = gameObject.GetComponent<EnemySpawn_insu>();
        Espawn= gameObject.GetComponentInChildren<EnemySpawn_insu>();
        //Espawn.gameObject.SetActive(false);
        // cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
     
    }

    // Update is called once per frame
    void Update()
    {
        //if(cv.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition > 1.0f)
        //{
        //    Debug.Log("1번째 돌입");
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Checking == false)
        {
            if (other.gameObject.tag == "Player")
            {
                Checking = true;
                playableDirector.Pause();
                
                //Espawn.gameObject.SetActive(true);
                Espawn.spawnCheck = true;
                gameObject.GetComponent<SphereCollider>().enabled = false;
                //StartCoroutine(BattleTime());
                StartCoroutine(DuringBattle());
            }
        }
    }

    
    IEnumerator BattleTime()
    {
        yield return new WaitForSeconds(3f);
        playableDirector.Play();
    }
    IEnumerator DuringBattle()
    {
        //yield return new WaitUntil(() => Espawn.battleOff == true);
        //playableDirector.Play();
        while(Espawn.battleOff==false)
        {
            yield return null; 
        }
        playableDirector.Play();

    }

}
