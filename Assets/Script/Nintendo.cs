using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nintendo : MonoBehaviour
{
    // variable estática para acceder al script
   public static Nintendo nm;
    //Variable con particulas
    public GameObject shine;
    //variable para giro de nintendo
    float velocidadGiro = 100;

    public bool obtained=false;
    
    //Animacion
    Animator anim;
    bool stopAnim = false;

  

    void Start()
    {
        //inicializo variable que referencia a este script
        nm = this;
        //inicializo anim
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopAnim)
        {
            transform.Rotate(0, 0, velocidadGiro * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("He colisionado por primera vez");
            GetComponent<CapsuleCollider>().enabled = false;
            //Añadir Sprite al Gestor Mochila
            ItemManager.itemMan.SpriteCreator(0);
           
            
            //ACTIVAR ANIMACION 
            anim.SetTrigger("CollectGadget");

            //HELP!! Obtained para cuando guarde partida?
            obtained = true;
            print(obtained);
           
          //  ParachutePrefab.ppm.ParachuteCheck();
        }
    }

    //Ambas funciones son llamadas como eventos en la animacion collectGadget
    public void DestroyGadget()
    {
        stopAnim = true;
        //Save as Disabled for next load
        ItemManager.itemMan.disabled.Add(gameObject.name);

        //Delete
        gameObject.SetActive(false);
    }

    public void ParticulasGadget()
    {
        //Iniciar particulas
        Instantiate(shine, transform.position, Quaternion.identity);
                
    }




}
