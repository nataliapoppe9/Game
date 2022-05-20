using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed,turnSpeed;
    Rigidbody rig;


    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
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
        // rig.velocity = ((this.transform.forward * input.y)  * speed * Time.deltaTime);


        rig.AddForce((this.transform.forward * input.y) * speed * Time.deltaTime);
        //Rotacion simple con transform
        transform.Rotate((Vector3.up * input.x) * turnSpeed * Time.deltaTime);

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
