using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotaManager : MonoBehaviour
{
    //Acceso a PlayerMovement para mover al personaje a la vez que el plano hielo
    public static PlayerMovement gm;

    //auxiliares
    int i=0;
    bool move = false;


    private void FixedUpdate()
    {
        //Si la gota collisiona conmigo activara move y podre entrar al if
        if (move)
        {
            //Muevo el plano
            Moving();
            //Muevo al character desde PlayerMovement
            PlayerMovement.pm.MoveWithWater();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //si la colision es con character
        if (collision.collider.name.Contains("Character"))
        {
            //activo move en update
            print("moveON");
            move = true;
            PlayerMovement.pm.platform = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name.Contains("Character"))
        {
            //activo move en update

            PlayerMovement.pm.platform = false;
        }
    }




    private void Moving()
    {
        //En cada frame del update se ejecutara moving añadiendo 1 a su posición
        //Se repetirá 80 veces
        if (i < 80)
        {
            //Muevo en z 1 la posicion del hielo.

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            //80veces
            i++;

        }
        else { move = false; }
    }
    

}
