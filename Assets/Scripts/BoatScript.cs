using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    public static BoatScript bsm;
   
    [SerializeField] float speed;
    [SerializeField]Transform destino;

    [SerializeField] GameObject boat;
    [SerializeField] GameObject player;

    bool startGo=false;
    public bool startAmonite = false;

    private void OnCollisionEnter(Collision collision)
    {
        //si la colision es con character
        if (collision.collider.name.Contains("Character"))
        {
            if (CanvasManager.gm.boatCoin)
            {
               // GameObject player = GameObject.FindGameObjectWithTag("Player");
                print("tengo ficha barco");
                startGo = true;
               
                CanvasManager.gm.boatCoin = false;

            }
            else { print("no tienes la ficha barco"); }
        }
        if (collision.collider.name.Contains("Destino"))
        {
            startGo = false;
            //player.transform.SetParent(null, true);
            transform.DetachChildren();
            //player.transform.parent = null;
            print("llegue a la isla");
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            collision.collider.GetComponent<BoxCollider>().enabled=false;
          
            

        }
    }

   
    private void Update()
    {
        
        if (startGo)
        {
            print("moving");
            transform.Translate(-Vector3.forward * speed* Time.deltaTime);
            player.transform.parent = transform;
           // player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

 
}

