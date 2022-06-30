using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject amonite;

    [SerializeField] Transform[] spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        SpawnAmonite();
    }

    

   void SpawnAmonite()
    {
        for(int i=0; i < spawnPoint.Length; i++)
        {
            GameObject newAmonite = Instantiate(amonite, spawnPoint[i].position, spawnPoint[i].rotation);
            amonite.transform.position = spawnPoint[i].position;
           // amonite.gameObject.SetActive(true);
            //amonite.GetComponent<NavMeshAgent>().enabled = true;

            // GameObject newBullet = Instantiate(bullet, shootPoint[cont].position, shootPoint[cont].rotation);

                //newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);

                //Instantiate(bullet, shootPoint[cont].position, shootPoint[cont].rotation).GetComponent<Rigidbody>().AddForce(shootPoint[cont].forward * shootForce);

                //Destroy(newBullet, 3);
        }

    }
}
