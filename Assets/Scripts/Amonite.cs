using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Amonite : MonoBehaviour
{
    Transform player;
    NavMeshAgent agent;

    public static Amonite am;

    bool start;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        am = this;
        start = false;
    }

    private void FixedUpdate()
    {
        if (start==true)
        {
            agent.SetDestination(player.position);
        }
    }

    public void StartAmonite()
    {
        print("start");
        start = true;
    }

    
}
