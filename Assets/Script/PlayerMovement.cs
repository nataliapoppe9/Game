using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // variable estática para acceder al script
    public static PlayerMovement pm;


    [SerializeField] int newGravity;
    //GameOver
    // public delegate void PlayerDelegate();
    //public static event PlayerDelegate OnPlayerDie;
    bool once = false;

    //Movement
    [SerializeField] float speed, turnSpeed, turnCamSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float setaForce;
    Rigidbody rig;

    public bool allowMovement = true;
    public bool usingParachute = false;

    public bool platform = false;
    bool dead = false;

    

    //Camera
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject cameraAguila;

    //raycast
    Ray ray;
    RaycastHit hit;
    [SerializeField] Transform pies;
    [SerializeField] LayerMask layer;

    //Animacion Seta
    Animator animSeta;

    //salto
    bool isJumping = false;

    private void Awake()
    {
        camera1.SetActive(true);

    }
    private void Start()
    {
        //inicializo rigidbody
        rig = GetComponent<Rigidbody>();
        //Inicializo el script para que sea acesible por CanvasManager
        pm = this;
        
    }

   

    private void Update() // cada frame. Atento a los imput
    {
        if (!GameManager.gameIsPaused)
        {
            
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !usingParachute)
            {

                Jump();
            }

            if (Input.GetKeyDown(KeyCode.Space) && !isJumping && usingParachute)
            {
                ParachuteJump();
            }

                CameraControl();
        }
    }
                               
    private void FixedUpdate() // Es constante. Va bien para el movimiento porque es cada X. No para imput pq quizas te saltes el frame en el q estaba pulsando // Se para con deltaTime
    {
        if (camera1.activeInHierarchy && !dead )
        {
            if (allowMovement)
            {
                Movement();
                
            }
            Rotating();
            Grounded();
        }
    }



    public void MovePlayerWithPlat()
    {
        StartCoroutine(MovingWithPlatform());
    }

    IEnumerator MovingWithPlatform()
    {
        for (int i = 0; i < 30; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
            yield return new WaitForSeconds(0.07f);
        }
    }

    public void GoBackWithPlatform()
    {
        print("Imove");
        StartCoroutine(MovingBackWithPlatform());
      /*  for (int i = 0; i < 30; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
        }*/
    }

    IEnumerator MovingBackWithPlatform()
    {
        for (int i = 0; i < 30; i++)
        {
            print("im moving");
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
            yield return new WaitForSeconds(0.07f);
        }
    }

    private void Movement()
    {
        float inputY = Input.GetAxis("Vertical");


      

        //-> NO VALE PQ SINO NO SE HUNDE
        //velocidad constante hacia delante con flecha alante * speed 
        //rig.velocity = ((this.transform.forward * input.y)  * speed * Time.deltaTime);

        //No necesitamos Time.deltaTime porque esta en FixedUpdate
        rig.AddForce((this.transform.forward * inputY) * speed);

        // WALKING ANIMATION -> animator
        if (inputY != 0)
        {
            GetComponent<Animator>().SetBool("IsWalking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsWalking", false);
        }



    }

    void Rotating()
    {
        float inputX = Input.GetAxis("Horizontal");

        //Rotacion simple con transform
        transform.Rotate((Vector3.up * inputX) * turnSpeed);
      

  
        if (inputX > 0)
        {
            GetComponent<Animator>().SetBool("IsRotatingRight", true);
            // GetComponent<Animator>().SetBool("IsRotatingLeft", false);
        }
        else if (inputX < 0)
        {
            GetComponent<Animator>().SetBool("IsRotatingLeft", true);
        }
        else { GetComponent<Animator>().SetBool("IsRotatingRight", false);
            GetComponent<Animator>().SetBool("IsRotatingLeft", false);
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
       
    }

    private void ParachuteJump()
    {
        //ParachutePrefab.ppm.UseParachute();
        
        gameObject.transform.GetChild(14).gameObject.SetActive(true);
        rig.AddForce(transform.up * jumpForce * 5, ForceMode.Impulse);
        isJumping = false;
        Physics.gravity = new Vector3(0, newGravity, 0);
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

        //print(isJumping + hit.collider.name);


        //La posición en y de aquello con lo que choca
        Vector3 suelo = new Vector3(0, hit.transform.position.y, 0);
        //Mi posicion en y
        Vector3 yo = new Vector3(0, pies.transform.position.y, 0);
        
        // Distancia entre aquello con lo que choca y yo. MI ALTURA DE LO Q HAYA BAJO MIS PIES
        float distancia = yo.y - suelo.y;
        
        //print(hit.collider.name + " " + distancia);
       
        
        //Si choco con la isla y mi altura es menos a 26 (en collision estoy a 25aprox), considero que ya no estoy saltando
       //y puedo volver a saltar
        if(hit.collider.name.Contains("ISLA1") && distancia<=26)
        {
            //puedo saltar de nuevo
            IsJumpingToFalse();
        }

        else if (hit.collider.name.Contains("ISLA2") && distancia <= 16)
        {
            //puedo saltar de nuevo
            IsJumpingToFalse();
        }

        //si choco con la isla, en collision estoy a 4aprox, mientras esta altura sea menor a 5 puedo saltar
        // ademas añado un impulso para llegar a la moneda
        else if (hit.collider.name.Contains("Seta"))
        {

            

            // activar animación seta(HELPPP)
            animSeta = hit.collider.GetComponent<Animator>();
            animSeta.SetTrigger("GrowSeta");
           // CameraController.cc.CameraJump();
        }
        else if (hit.collider.isTrigger && hit.collider.name.Contains("Agua") && !usingParachute)
        {

            dead = true;
            OnGameOverPlayer();
        }
        else if (hit.collider.isTrigger && hit.collider.name.Contains("Agua") && usingParachute && distancia<66)
        {
            print(distancia);
            dead = true;
            OnGameOverPlayer();
        }
        else if (hit.collider.name.Contains("IslaBoat")&& distancia<34)
        {
           // print("IslaBoat");
            IsJumpingToFalse();

            if (once == false)
            {
                Amonite.am.SpawnAmonite();
                once = true;
                PlayerPrefs.SetInt("Once", (once ? 1 : 0));
            }

          
        }
        else if (hit.collider.name.Contains("ISLA3") && distancia < 32)
        {
            print("IslaBoat");
            IsJumpingToFalse();
        }
        else if (hit.collider.name.Contains("IslaAlto") && distancia < 27)
        {
            print("IslaAlto");
            IsJumpingToFalse();
        }
        //else { print("no conozco el suelo"+ hit.collider.name + distancia); }

        //pinto el rayo en el editor
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);

       
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (usingParachute)
        {
            gameObject.transform.GetChild(14).gameObject.SetActive(false);
         
        }
    }

    public void IsJumpingToFalse()
    {
        isJumping = false;

       
        Physics.gravity = new Vector3(0, -9.81f, 0);
        //if (GameObject.Find("Cinematic TimeLine"))
        //{
        //    GameObject.Find("Cinematic TimeLine").SetActive(false);
        //}

    }


   

    void OnGameOverPlayer()
    {
        print("Drown");
        GetComponent<Animator>().SetBool("IsWalking", false);//
        GetComponent<Animator>().SetTrigger("Drown");
        CanvasManager.gm.GameOverPanel();
       
        StartCoroutine(DestroyCharacter());
       
    }

    IEnumerator DestroyCharacter()
    {
        
        print("destroy");
        yield return new WaitForSeconds(5);
        print("destroy");
        Destroy(this.gameObject);
    }

}
