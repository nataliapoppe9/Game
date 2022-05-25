using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // variable estática para acceder al script
    public static PlayerMovement gm;

    //Movement
    [SerializeField] float speed, turnSpeed, turnCamSpeed;
    [SerializeField] float jumpForce;
    Rigidbody rig;

    int i = 0;

    //Camera
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject cameraAguila;


    //Rewards ¿MEjor en GameManager?
    public int numCoins = 0;

    //raycast
    Ray ray;
    RaycastHit hit;
    [SerializeField] Transform pies;
    [SerializeField] LayerMask layer;



    //salto
    bool isJumping = false;

    private void Start()
    {
        //inicializo rigidbody
        rig = GetComponent<Rigidbody>();
        //cojo este script para poder ser accedido desde otro
        gm = this;

      
    }
   
    private void FixedUpdate()
    {
        if (camera1.activeInHierarchy)
        {
            Movement();

            Grounded();

            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                Jump();
                // GetComponent<Animator>().SetBool("IsJump", true);


            }

            AnimationJump();
        }
        
        CameraControl();

       
    }
   public void AnimationJump()
    {
       
    }
   public void AddCoin() // mejor en game manager???
    {
        numCoins += 1;
        print(numCoins);
    }

    //Funcion que se activa desde GotaManager
    //Cuando la gota colisiona conmigo se activa esta función en su update
    //Con esto me muevo a la vez que el plano de la gota
    public void MoveWithWater()
    {
        print("movewithwater");
        //Para que cambie su posición en Z HASTA 80
        if (i < 80)
        {
            //Vector con mi posición +1 en Z en cada update
            Vector3 end = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);

            //Instruccion de cambiar mi posicion a +1 en z. Se ejecuta dentro de update 80 veces y deja de ejecutarse
            transform.position = end;
            i++;

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
    private void CameraControl()
    {

        //si pulso C
        if (Input.GetKeyDown(KeyCode.C))
        {

            camera1.SetActive(!camera1.activeInHierarchy);
            cameraAguila.SetActive(!cameraAguila.activeInHierarchy);



        }
        // si NO pulso C
        else if (!Input.GetKey(KeyCode.C))
        {

           
        }
    }
    
    public void Jump()
    {
        //En cuanto salta, deja de poder saltar
        //Con grounded() modifico if jumping para que pueda volver a saltar
        isJumping = false;


        GetComponent<Animator>().SetTrigger("Jumping");
        GetComponent<Animator>().SetBool("IsWalking", false);

        //fuerza de salto
        rig.AddForce(this.transform.up * jumpForce, ForceMode.Impulse);   
        
    }

    void Grounded()
    {
        
        //ORIGEN Y DIRECCION DEL RAYCAST
        ray.origin = pies.transform.position;
        ray.direction = -Vector3.up;

        //Inicializo el raycast 
        isJumping = Physics.Raycast(ray, out hit);
       
        // siempre sale true -> BIEN. está emitiendo el rayo. 
        // DEBERIA AÑADIR UNA CONDICION PARA  LA CREACION DEL RAYO. pero asi funciona y nose cambiarlo

        print(isJumping + hit.collider.name);


        //La posición en y de aquello con lo que choca
        Vector3 suelo = new Vector3(0, hit.transform.position.y, 0);
        //Mi posicion en y
        Vector3 yo = new Vector3(0, pies.transform.position.y, 0);
        
        // Distancia entre aquello con lo que choca y yo. MI ALTURA DE LO Q HAYA BAJO MIS PIES
        float distancia = yo.y - suelo.y;
        print(hit.collider.name + " " + distancia);
       //Si choco con la isla y mi altura es menos a 26 (en collision estoy a 25aprox), considero que ya no estoy saltando
       //y puedo volver a saltar
        if(hit.collider.name.Contains("ISLA") && distancia<=26)
        {
            //puedo saltar de nuevo
            IsJumpingToFalse();
        }

        //si choco con la isla, en collision estoy a 4aprox, mientras esta altura sea menor a 5 puedo saltar
        // ademas añado un impulso para llegar a la moneda
        else if (hit.collider.name.Contains("Seta") && distancia <= 6)
        {
            // Dar extra fuerza
            rig.AddForce(this.transform.up * jumpForce*2, ForceMode.Impulse);
            IsJumpingToFalse();


            // activar animación seta(HELPPP)

        }
      

        //animacion salto


        //pinto el rayo en el editor
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
       
    }

    //Sera llamada desde la animacion FLIP
    public void IsJumpingToFalse()
    {
        isJumping = false;
        
    }

}
