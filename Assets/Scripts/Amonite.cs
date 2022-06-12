using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Amonite : MonoBehaviour
{
    Transform player;

    [SerializeField] GameObject amonite;
    [SerializeField] Transform[] spawnPoint;
    NavMeshAgent agent;

    public static Amonite am;

    public List<GameObject> amoniteList;

    bool start;
    public List<int> startedNum;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       // agent = GetComponent<NavMeshAgent>();
        am = this;
        start = false;
       // SpawnAmonite();
    }


    public void SpawnAmonite()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {

            GameObject newAmonite = Instantiate(amonite, spawnPoint[i].position, spawnPoint[i].rotation);
            newAmonite.transform.position = spawnPoint[i].position;
            newAmonite.transform.name = "Amonite" + i;
            amoniteList.Add(newAmonite);
            
        }
        
    }



    private void FixedUpdate()
    {
        if (start)
        {
            for(int i=0; i<5; i++)
            {
                if (startedNum.Contains(i))
                {
                    OneFollowsPlayer(i);
                }
            }
            
        }

    }

    public void StartAmonite(int j)
    {
        print("he empezado Amonite" + j);
        start = true;
       // startNum = j;
        startedNum.Add(j);
        
    }
   public void OneFollowsPlayer(int i)
    {
        agent = amoniteList[i].GetComponent<NavMeshAgent>();
        agent.transform.LookAt(-1 * (player.transform.position));
        agent.SetDestination(player.position);
    }

    void AllFollowPlayer()
    {
        //NO LO ESTOY USANDO

            print("startNavMeshAgent" + amoniteList.Count);
            for (int i = 0; i < amoniteList.Count; i++)
            {
                agent = amoniteList[i].GetComponent<NavMeshAgent>();
                agent.transform.LookAt(-1 * (player.transform.position));
                agent.SetDestination(player.position);
            }
            /*foreach(GameObject item in amoniteList)
            {
                print(item.gameObject.name);
                agent= item.GetComponent<NavMeshAgent>();
                agent.transform.LookAt(-1*(player.transform.position));
                agent.SetDestination(player.position);
            }*/
    }

}
