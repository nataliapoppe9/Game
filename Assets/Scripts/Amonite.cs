using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class Amonite : MonoBehaviour
{
    public float radius;
    public Transform force;

    Transform player;

    [SerializeField] GameObject amonite;
    [SerializeField] Transform[] spawnPoint;
    NavMeshAgent agent;

    public static Amonite am;

    public List<GameObject> amoniteList;

    public GameObject TimeLine;

    bool start;
    public List<int> startedNum;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
        am = this;
        start = false;
       
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
        //agent.transform.LookAt(-1 * (player.transform.position));
        agent.SetDestination(player.position);
        agent.GetComponent<Collider>().enabled = false;
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

   public void MoveAroundForce(Transform forceField)
    {
        start = false;

        //Quiero iniciar Cutscene con Timeline. Play
       // TimeLine.GetComponent<TimelineAsset>()
        print("move Around" + forceField.gameObject.name);
        for(int i=0; i<amoniteList.Count;i++)
        {

            amoniteList[i].GetComponent<NavMeshAgent>().SetDestination(
             new Vector3(
                forceField.position.x + radius * Mathf.Cos(2 * Mathf.PI * i / amoniteList.Count),
                player.position.y,
                forceField.position.z + radius * Mathf.Sin(2 * Mathf.PI * i / amoniteList.Count)));
            print(amoniteList[i].gameObject.name);
        }
    }

}
