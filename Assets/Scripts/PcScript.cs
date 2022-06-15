using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcScript : MonoBehaviour
{
    // variable estática para acceder al script
    public static PcScript pcs;
    //Variable con particulas
    public GameObject shine;
    public Transform positionPC; // Pq el gameObject no esta bien centrado
    bool stopAnim;
    float velocidadGiro=100;
    //Animacion
    Animator anim;

    void Start()
    {
        //inicializo variable que referencia a este script
        pcs = this;
        //inicializo anim
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!stopAnim)
        {
            transform.Rotate(0, -velocidadGiro * Time.deltaTime,0);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("He colisionado con PC");
            GetComponent<CapsuleCollider>().enabled = false;
            //Añadir Sprite al Gestor Mochila
            ItemManager.itemMan.SpriteCreator(1);

            //ACTIVAR ANIMACION 
            anim.SetTrigger("getPC");
        }
    }

    public void ParticulasPC()
    {
        
        //Iniciar particulas
        Instantiate(shine, positionPC.position, Quaternion.identity);

    }

    public void DestroyPC()
    {
        stopAnim = true;
        print("destroy");
        Destroy(this.gameObject);
    }
}
