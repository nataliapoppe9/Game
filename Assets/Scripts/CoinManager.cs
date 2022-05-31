using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

   


    private void Update()
    {
        transform.Rotate(transform.up);
    }
    public void OnCollisionEnter(Collision collision)
    {
       
        //si el player colisiona con un Coin
        if ((collision.gameObject.name.Contains("Character")))
        {

        
           // print("colisionCOIN");

            //desactivo el collider ¿hace falta?Nose
            //destruyo el objeto
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject);

            //LLAMAR A UNA FUNCION AddCoin();
            // La función estará en el script CanvasManager.gm
            CanvasManager.gm.AddCoin();
            
        }
    }
  
}
