using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.name.Contains("Character")))
        {
            print("colisionCOIN");
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject);
            //LLAMAR A UNA FUNCION AddCoin();
            // La funci�n estar� en el script PlayerMovement.gm
            PlayerMovement.gm.AddCoin();
            
        }
    }
  
}
