using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        print("he colisionado");
        if (collision.gameObject.CompareTag("Player"))
        {
            print("con player");
            //animacion y destroy

            Destroy(gameObject);
            print("destruir");
        }
    }
}
