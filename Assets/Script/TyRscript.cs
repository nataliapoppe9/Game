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
            //A?adir Sprite al Gestor Mochila
            ItemManager.itemMan.SpriteCreator(2);

            //ACTIVAR ANIMACION 
            anim.SetTrigger("getTeclado");

           // ParachutePrefab.ppm.ParachuteCheck();
        }
    }

    public void DestroyTyR()
    {
       
        
        print("destroy");
        ItemManager.itemMan.disabled.Add(gameObject.name);
        gameObject.SetActive(false);

    }

    public void ParticulasTyR(GameObject shine)
    {

        //Iniciar particulas
        Instantiate(shine, gameObject.transform.position, Quaternion.identity);

    }

}
