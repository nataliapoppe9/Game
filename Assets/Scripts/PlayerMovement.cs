using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // variable estática para acceder al script
    public static PlayerMovement gm;

    //Movement
    public float speed,turnSpeed, turnCamSpeed;
    public float jumpForce;
    Rigidbody rig;

    //Camera
    [SerializeField] Camera myCamera;
    [SerializeField] Camera cameraView;
    

    //Rewards ¿MEjor en GameManager?
    public int numCoins;

    //raycast
    Ray ray;
    RaycastHit hit;
    public Transform pies;
    [SerializeField] LayerMask layer;



    //salto
    bool isJumping = false;

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

        Grounded();
        
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
           Jump();
        }

    }

   public void AddCoin() // mejor en game manager?
    {
        numCoins += 1;
        print(numCoins);
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
    private void CameraControl()
    {

        //si pulso C
        if (Input.GetKey(KeyCode.C))
        {

            //cambio config
            cameraView.enabled = true;
            myCamera.enabled = false;
            RotateCam();
            

        }
        // si NO pulso C
        else if (!Input.GetKey(KeyCode.C))
        {

            //cambio config
            cameraView.enabled = false;
            myCamera.enabled = true;
        }
    }
    void RotateCam()
    {

        Vector2 inputC = new Vector2(
           Input.GetAxis("RotCamH"),
           Input.GetAxis("RotCamV"));

        // normalizamos el vector
        inputC = inputC.normalized;

       // cameraView.transform.Rotate((Vector3.up * inputC.x) * turnCamSpeed);
       cameraView.transform.Rotate((Vector3.right * inputC.y) * turnCamSpeed);

                   
    }
    public void Jump()
    {
        isJumping = false;

        rig.AddForce(this.transform.up * jumpForce, ForceMode.Impulse);      
    }

    void Grounded()
    {
        ray.origin = pies.transform.position;
        ray.direction = -Vector3.up;

        // Debug.Log("El rayo choca contra el suelo" + hit.transform.position.y + " mi posicion es" + pies.transform.position.y);

        isJumping = Physics.Raycast(ray, out hit);
       
        print(isJumping + hit.collider.name);

        Vector3 suelo = new Vector3(0, hit.transform.position.y, 0);
        Vector3 yo = new Vector3(0, pies.transform.position.y, 0);
        
        float distancia = yo.y - suelo.y;

       // print("yo" +yo.y +"suelo"+ suelo.y +"dist" + distancia);
        //if (distancia <= 26)
        print(hit.collider.name+ distancia);
        if(hit.collider.name.Contains("ISLA") && distancia<=26)
        {

            isJumping = false;

        }

        if (hit.collider.name.Contains("Seta") && distancia <= 5)
        {
            // Dar extra fuerza
            // activar animación
            rig.AddForce(this.transform.up * jumpForce*2, ForceMode.Impulse);
            isJumping = false;

        }

        // if (hit.collider.name.Contains("ISLA")) { isJumping = false; }


        //NO LO USO PARA NADA DE MOMENTO
        /* if (isJumping)
         {
             Vector3 suelo = new Vector3(0, hit.transform.position.y, 0);
             Vector3 yo = new Vector3(0, pies.transform.position.y, 0);
             yo.y = yo.y - 25 + 0.11215f;
             float distancia = yo.y - suelo.y;
         }*/

        /*  if (distancia < 1.5f)
          {

              // print("grounded"+ "yo:" + yo.y + "suelo:" + suelo.y + "dist" +distancia);
              grounded = true;

          }*/


        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
       // print("El nombre es: " + hit.collider.name);
    }

  /*  private void OnCollisionEnter(Collision collision)
    {
      //  print("choco con "+ collision.collider.name);
        if (collision.collider.name == "Seta")
        {
          //  Debug.Log("Choco con Seta SEGURO");
        }
    }*/

}
