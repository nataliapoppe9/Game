using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcPantalla : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Pantalla collision");
            GetComponent<BoxCollider>().enabled = false;
            //Añadir Sprite al Gestor Mochila
            ItemManager.itemMan.SpriteCreator(3);

            //ACTIVAR ANIMACION 
            anim.SetTrigger("getPantalla");
        }
    }

    public void DestroyPant()
    {


        print("destroy");
        ItemManager.itemMan.disabled.Add(gameObject);
        Destroy(gameObject);

    }

    public void ParticulasPant(GameObject shine)
    {

        //Iniciar particulas
        Instantiate(shine, gameObject.transform.position, Quaternion.identity);

    }
}
