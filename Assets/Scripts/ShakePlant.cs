using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakePlant : MonoBehaviour
{
    //Spawn Coins
    private GameObject coin;
    private Vector3 offset;

    //Animacion
    Animator anim;
   
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
      // Si el player collisiona con la planta
        if ((collision.gameObject.name.Contains("Character")))
        {
            print("colision");
            //funcion de este mismo script
            SpaunCoins();

            //ACTIVAR ANIMACION (no funciona)
            //¿config unity?
            anim.Play("ShakePlant");

            //desactivo colider
            GetComponent<Collider>().enabled = false;

        }

        
    }

    void SpaunCoins()
    {
     
        //bucle para instanciar 3 veces
        for(int i=0; i<3; i++)
        {
            //separo los coins en x & z. Hacia arriba No
            offset = new Vector3(-i-1, 0, i+1);
            
            Instantiate(coin, transform.position + offset*10, transform.rotation);
        }
    }
}
