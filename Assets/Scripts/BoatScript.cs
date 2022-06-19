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

    bool startGo=false;
   

    private void OnCollisionEnter(Collision collision)
    {
        //si la colision es con character
        if (collision.collider.name.Contains("Character"))
        {
            if (CanvasManager.gm.boatCoin)
            {
                print("tengo ficha barco");
                startGo = true;
               
                CanvasManager.gm.boatCoin = false;

            }
            else { 
                
                print("no tienes la ficha barco"); }
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

    }

    public void SoltarBarco(Collider col)
    {
        //player.transform.SetParent(null, true);
        transform.DetachChildren();
        //player.transform.parent = null;
        print("llegue a la islaVuelta");
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        col.GetComponent<BoxCollider>().enabled = false;
        startGo = false;

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
        if (destino.gameObject.GetComponent<Collider>().enabled==false)
        {
            destinoVuelta.gameObject.GetComponent<Collider>().enabled = true;
            BackBoat();

        }
        else if (destinoVuelta.gameObject.GetComponent<Collider>().enabled == false)
        {
            destino.gameObject.GetComponent<Collider>().enabled = true;
            MoveBoat();
        }
    }


}

