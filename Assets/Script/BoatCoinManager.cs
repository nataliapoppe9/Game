using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCoinManager : MonoBehaviour
{

    private void FixedUpdate()
    {
       // transform.Rotate(transform.up);
    }

    public void OnCollisionEnter(Collision collision)
    {

        //si el player colisiona con un Coin
        if ((collision.gameObject.name.Contains("Character")))
        {

           
            // print("colisionCOIN");

            //desactivo el collider ?hace falta?Nose
            //destruyo el objeto
            GetComponent<Collider>().enabled = false;
            gameObject.SetActive(false);

            //LLAMAR A UNA FUNCION AddCoin();
            // La funci?n estar? en el script CanvasManager.gm
            CanvasManager.gm.AddBoatCoin();

        }
    }
}
