using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nintendo : MonoBehaviour
{
    // variable estática para acceder al script
   public static Nintendo nm;
    //Variable con particular premio
    public GameObject shine;
    //variable para giro de nintendo
    float velocidadGiro = 100;


    
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

            //Añadir Sprite al Gestor Mochila
            ItemManager.itemMan.SpriteCreator();
           
            
            //ACTIVAR ANIMACION 
            anim.SetTrigger("CollectGadget");
           
        }
    }

    public void DestroyGadget()
    {
        stopAnim = true;
        Destroy(gameObject);
    }

    public void ParticulasGadget()
    {
        //Iniciar particulas
        Instantiate(shine, transform.position, Quaternion.identity);
        //desactivo collider
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
