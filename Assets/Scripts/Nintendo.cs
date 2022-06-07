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

    //Camera with Gadget
    //Camera
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject cameraAguila;


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

            //HELP!!
            obtained = true;
            print(obtained);

        }
    }

    //Ambas funciones son llamadas como eventos en la animacion collectGadget
    public void DestroyGadget()
    {
        stopAnim = true;
        Destroy(gameObject);
    }

    public void ParticulasGadget()
    {
        //Iniciar particulas
        Instantiate(shine, transform.position, Quaternion.identity);
                
    }

    public void OnClickGadget()
    {
        camera1.SetActive(false);
        cameraAguila.SetActive(true);
    }


}
