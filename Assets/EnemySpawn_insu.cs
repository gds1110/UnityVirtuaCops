using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn_insu : MonoBehaviour
{
    [SerializeField]
    public GameObject enemyPrefab;
    public Transform[] spawnZone;
    public bool spawnCheck = false;
    public bool battleOff;
    public int monNum = 0;
    public float timer;
    public float waitTime;
    public int spawnNum = 0;
    public int deathCount = 0;
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.7f;
        waitTime = 0.8f;
        battleOff = false;
        spawnNum = spawnZone.Length;
    }
    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if(spawnCheck==true)
        {
            
            //for (int i = 0; i < spawnZone.Length; i++)
            //{
            //    StartCoroutine(WaitTime());
            //    Instantiate(enemyPrefab, spawnZone[i]);

            //    if(i==spawnZone.Length-1)
            //    {
            //        spawnCheck = false;
            //    }
            //}

            //StartCoroutine(MonsterGen(monNum));
            //monNum++;
            //if(monNum>=spawnZone.Length)
            //{
            //    spawnCheck = false;
            //}
            if(timer>waitTime)
            {
                timer = 0;
                //Instantiate(enemyPrefab, spawnZone[monNum++]);
                var Zombie = Instantiate(enemyPrefab, spawnZone[monNum].position,Quaternion.identity,spawnZone[monNum].parent).GetComponent<FollowPlayer>();
               // Zombie.target = GetComponentInParent<BattleZoneCheck>().target;
                if (spawnZone[monNum].position.y<1.0f)
                {
                    Zombie.isWalk = true;
                }
                else
                {
                    Zombie.isWalk = false;
                }
                    monNum++;
                if (monNum >= spawnZone.Length)
                {
                    spawnCheck = false;
                }
                
            }
            
        }
        if (deathCount==spawnNum)
        {
            battleOff = true;
        }

    }

    private void OnEnable()
    {
        //spawnCheck = true;

       
    }

    IEnumerator WaitTime()
    {

            yield return new WaitForSeconds(0.8f); // 생성 전 딜레이
        
    }  
    IEnumerator MonsterGen(int num)
    {
        Instantiate(enemyPrefab, spawnZone[num]);
        yield return new WaitForSeconds(5f); // 생성 전 딜레이
        
    }
}
