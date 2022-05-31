using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // variable estática para acceder al script
    public static PlayerMovement pm;

    //GameOver
   // public delegate void PlayerDelegate();
    //public static event PlayerDelegate OnPlayerDie;


    //Movement
    [SerializeField] float speed, turnSpeed, turnCamSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float setaForce;
    Rigidbody rig;


    public bool platform = false;
    bool dead = false;
    int i = 0;

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

        //NO SE HACER SINGLETON PARA QUE SE COMUNIQUE SOLO CON EL OTRO SCRIPT
        //Resquicio de intento anterior
        //GameOver.OnGameOver += OnGameOverPlayer;
    }
    private void Start()
    {
        //inicializo rigidbody
        rig = GetComponent<Rigidbody>();
        //Inicializo el script para que sea acesible por CanvasManager
        pm = this;


        
        //Recuperar posicion cuando Load Game 


      if (ChangeScene.cs.loaded)
        {
            print("positionLoad");
            if (PlayerPrefs.HasKey("PositionX") && PlayerPrefs.HasKey("PositionY") && PlayerPrefs.HasKey("PositionZ"))
            {
                print(PlayerPrefs.GetFloat("PositionX") + " " + PlayerPrefs.GetFloat("PositionY") + " " + PlayerPrefs.GetFloat("PositionZ"));
                transform.position = new Vector3(PlayerPrefs.GetFloat("PositionX"), PlayerPrefs.GetFloat("PositionY"), PlayerPrefs.GetFloat("PositionZ"));
                transform.rotation = Quaternion.Euler(PlayerPrefs.GetFloat("RotX"), PlayerPrefs.GetFloat("RotY"), PlayerPrefs.GetFloat("RotZ")) ;
            }
        }
      
        
    }

    private void Update() // cada frame. Atento a los imput
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }
        CameraControl();
    }

    private void FixedUpdate() // Es constante. Va bien para el movimiento porque es cada X. No para imput pq quizas te saltes el frame en el q estaba pulsando
    {
        if (camera1.activeInHierarchy && !dead)
        {
            Movement();
            Grounded();
        }
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
            //Vector con mi posición +1 en Z en cada update ( Para que se mueva a la vez q el suelo)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);

            //Instruccion de cambiar mi posicion a +1 en z. Se ejecuta dentro de update 80 veces y deja de ejecutarse
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
        if(hit.collider.name.Contains("ISLA") && distancia<=26)
        {
            //puedo saltar de nuevo
            IsJumpingToFalse();
        }

        //si choco con la isla, en collision estoy a 4aprox, mientras esta altura sea menor a 5 puedo saltar
        // ademas añado un impulso para llegar a la moneda
        else if (hit.collider.name.Contains("Seta"))
        {

            // Dar extra fuerza??

            // activar animación seta(HELPPP)
            animSeta = hit.collider.GetComponent<Animator>();
            animSeta.SetTrigger("GrowSeta");
           // CameraController.cc.CameraJump();
        }
        else if (hit.collider.isTrigger && hit.collider.name.Contains("Agua"))
        {
            dead = true;
            OnGameOverPlayer();
        }


        //pinto el rayo en el editor
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
       
    }

    //Sera llamada desde la animacion FLIP
    public void IsJumpingToFalse()
    {
        isJumping = false;
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
