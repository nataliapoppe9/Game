using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyRscript : MonoBehaviour
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
            print("TyR collision");
            GetComponent<BoxCollider>().enabled = false;
            //Añadir Sprite al Gestor Mochila
            ItemManager.itemMan.SpriteCreator(2);

            //ACTIVAR ANIMACION 
            anim.SetTrigger("getTeclado");
        }
    }

    public void DestroyTyR()
    {
       
        
        print("destroy");
        ItemManager.itemMan.disabled.Add(gameObject);
        Destroy(gameObject);

    }

    public void ParticulasTyR(GameObject shine)
    {

        //Iniciar particulas
        Instantiate(shine, gameObject.transform.position, Quaternion.identity);

    }

}
