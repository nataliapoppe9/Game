using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    public static BoatScript bsm;
   
    [SerializeField] float speed;
    [SerializeField] Transform destino,destinoVuelta;

    [SerializeField] GameObject boat;
    [SerializeField] GameObject player;

    public ParticleSystem lightParticles;


    bool startGo=false;

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Contains("Character"))
        {

             if(BoatInfoTent.canUse)
              {
                  startGo = true;
                  CanvasManager.gm.boatCoin = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                PlayerMovement.pm.allowMovement = false;

            }
              else
              {

                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                print("Boat on arrival");
              }


        }
        if (collision.collider.name.Contains("Destino"))
        {

            SoltarBarco(collision.collider);


        }
        if (collision.collider.name.Contains("DestinoVuelta"))
        {

            SoltarBarco(collision.collider);

        }
    }

   
    private void Update()
    {
       
        
        if (startGo)
        {
            ControlColliderDestino();
        }

      
       
        if (BoatInfoTent.canUse)
        {

            lightParticles.gameObject.SetActive(true);
            
            print("tengoFichaBarco");
            
        }
        else { 
            lightParticles.gameObject.SetActive(false);
        }

        

    }

    public void SoltarBarco(Collider col)
    {
        PlayerMovement.pm.allowMovement = true;
        transform.DetachChildren();

        print("llegue a la islaVuelta");
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        col.GetComponent<BoxCollider>().enabled = false;
        startGo = false;

        BoatInfoTent.canUse = false;


    }

    public void MoveBoat()
    {
        print("moving");
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        player.transform.parent = transform;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        // player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void BackBoat()
    {
        print("moving");
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        player.transform.parent = transform;
        // player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void ControlColliderDestino()
    {
        if (destino.gameObject.GetComponent<Collider>().enabled==false && BoatInfoTent.canUse)
        {
            destinoVuelta.gameObject.GetComponent<Collider>().enabled = true;
            BackBoat();

        }
        else if (destinoVuelta.gameObject.GetComponent<Collider>().enabled == false && BoatInfoTent.canUse)
        {
            destino.gameObject.GetComponent<Collider>().enabled = true;
            MoveBoat();
        }
    }


}

