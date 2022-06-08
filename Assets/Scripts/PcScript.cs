using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcScript : MonoBehaviour
{
    // variable estática para acceder al script
    public static PcScript pcs;
    //Variable con particulas
    public GameObject shine;
    //variable para giro de nintendo
    // float velocidadGiro = 100;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("He colisionado con PC");
            GetComponent<CapsuleCollider>().enabled = false;
            //Añadir Sprite al Gestor Mochila
            ItemManager.itemMan.SpriteCreator(1);
        }
    }

    public void ParticulasPC()
    {
        //Iniciar particulas
        Instantiate(shine, transform.position, Quaternion.identity);

    }
}
