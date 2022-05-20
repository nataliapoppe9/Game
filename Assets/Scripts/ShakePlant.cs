using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakePlant : MonoBehaviour
{
    public GameObject coin;
    Animator anim;

    private Vector3 offset;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
      
        if ((collision.gameObject.name.Contains("Character")))
        {
            print("colision");
            SpaunCoins();

            //ACTIVAR ANIMACION (no funciona)
            //¿config unity?
            anim.Play("ShakePlant");
            GetComponent<Collider>().enabled = false;

        }

        if ((collision.gameObject.name.Contains("Plane")))
        {
            print("dead");
        }
    }

    void SpaunCoins()
    {
     
        for(int i=0; i<3; i++)
        {
            
            offset = new Vector3(-i-1, 0, i+1);
            
            Instantiate(coin, transform.position + offset*10, transform.rotation);
        }
    }
}
