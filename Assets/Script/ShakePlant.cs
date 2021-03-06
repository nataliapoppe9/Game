using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakePlant : MonoBehaviour
{
    //Spawn Coins
    public GameObject coin;
    private Vector3 offset;

    //Animacion
    Animator anim;
    //Animator animChar;

    private void Start()
    {
        //inicializo anim
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
      // Si el player collisiona con la planta
        if ((collision.gameObject.CompareTag("Player")))
        {
            print("colision");
            //funcion de este mismo script
            SpawnCoins();

            //animChar = collision.gameObject.GetComponent<Animator>();
            //animChar.SetBool("IsWalking", false);
            //animChar.SetTrigger("ShakeIt");

            //ACTIVAR ANIMACION 
            anim.SetTrigger("ShakePlant");


            //desactivo colider
            GetComponent<Collider>().enabled = false;

        }

        
    }



    void SpawnCoins()
    {
     
        //bucle para instanciar 3 veces
        for(int i=0; i<3; i++)
        {
            //separo los coins en x & z. Hacia arriba NO
            offset = new Vector3(-i-1, 0, i+1);
            //Instancio los coins
            Instantiate(coin, transform.position + offset*10, transform.rotation);
        }
    }
}
