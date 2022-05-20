using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // variable estática para acceder al script
    public static PlayerMovement gm;

    //Movement
    public float speed,turnSpeed;
    Rigidbody rig;

    //Camera
    [SerializeField] Camera myCamera;
    [SerializeField] Camera cameraView;
    int count = 0;

    //Rewards ¿MEjor en GameManager?
    public int numCoins;

    private void Start()
    {
        //inicializo rigidbody
        rig = GetComponent<Rigidbody>();
        //cojo este script para poder ser accedido desde otro
        gm = this;


        //configuracion inicial de la camara
        cameraView.enabled = false;
        myCamera.enabled = true;

    }
   
    private void FixedUpdate()
    {
        Movement();

        CameraControl();
        
    }

   public void AddCoin() // mejor en game manager?
    {
        numCoins += 1;
        print(numCoins);
    }

    private void CameraControl()
    {
        //si pulso c y es la prrimera vez: (count se inicializó en 0)
        if ((Input.GetKeyDown(KeyCode.C)) && (count == 0))
        {
            //cambio config
            cameraView.enabled = true;
            myCamera.enabled = false;

            //sumo 1. Ahora count vale 1 y entrará en el siguiente if la segunda vez
            count++;
        }
        // si pulso c y es la segunda vez
        else if((Input.GetKeyDown(KeyCode.C)) && (count == 1))
        {
            //cambio config
            cameraView.enabled = false;
            myCamera.enabled = true;

            // pongo count a cero para que la tercera vez entre en el primero y se repita esta dinamica
            count = 0;
        }
    }
    private void Movement()
    {
        // creamos una variable vector2 para guardar el input de flechas < > y ^u
        Vector2 input = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));

        // normalizamos el vector
        input = input.normalized;


        //-> NO VALE PQ SINO NO SE HUNDE
        //velocidad constante hacia delante con flecha alante * speed 
        //rig.velocity = ((this.transform.forward * input.y)  * speed * Time.deltaTime);

        //No necesitamos Time.deltaTime porque esta en FixedUpdate
        rig.AddForce((this.transform.forward * input.y) * speed );
        //Rotacion simple con transform
        transform.Rotate((Vector3.up * input.x) * turnSpeed );

        // WALKING ANIMATION -> animator
        if (input.y !=0)
        {
            GetComponent<Animator>().SetBool("IsWalking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsWalking", false);
        }


    
    }

   
}
