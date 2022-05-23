using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotaManager : MonoBehaviour
{
    //condicion coins
    public static PlayerMovement gm;
    int numero;
    int i=0;
    bool move = false;


    private void FixedUpdate()
    {
        if (move)
        {
            Moving();
            PlayerMovement.gm.MoveWithWater();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("moveON");
        move= true;

        Vector3 yo = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.gameObject.transform.position.z);


    }

   


    private void Moving()
    {
        if (i < 80)
        {
            Vector3 end = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);

            transform.position = end;
            i++;

        }
        else { move = false; }
    }
    

}
