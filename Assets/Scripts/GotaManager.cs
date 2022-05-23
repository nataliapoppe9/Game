using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotaManager : MonoBehaviour
{
    //condicion coins
    public static PlayerMovement gm;
    int numero;
    int i=0;


    private void Start()
    {

        
    }

    private void Update()
    {
       
    }

    private void Moving()
    {
        if (i < 80)
        {
            Vector3 end = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);

            transform.position = end;
            i++;

        }
    }
    

}
