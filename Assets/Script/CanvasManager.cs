using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager gm;

    AudioSource audioSource;
    [SerializeField] AudioClip audioCoin;


    [SerializeField] GameObject panelGameOver;
    [SerializeField] GameObject snowflakes;
    // GameObject[] newSnowflakes;
    private Vector3 offset;
    Rigidbody2D rbSF;

    //Variables Mochila
    [SerializeField] GameObject mochilaButton;
    public GameObject panelMiMochila;
    bool closedBag = true;

    public int amoniteCount;
    public int numCoins;
    public bool boatCoin = false;
    public Text textCoins;

    [SerializeField] Transform particles, boat;
    private void Start()
    {
        //cojo este script para poder ser accedido desde otro
        gm = this;

        //inicializo textCoins y audiosource
        textCoins = GameObject.Find("TextScore").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
        textCoins.text = "S coins: " + numCoins.ToString();

       

        
        
           


        //print(ChangeScene.cs.loaded + "CARGARON LOS COINS");

        // Si he guardado partida y tengo almacenado el numero de coins
       /* if (PlayerPrefs.HasKey("numCoins") && ChangeScene.cs.loaded == true)
        {
            numCoins = PlayerPrefs.GetInt("numCoins"); // Cuando abrimos partida nueva recuperamos
            textCoins.text = "S coins: " + numCoins.ToString();
            print(numCoins);
        }

        if (PlayerPrefs.HasKey("BoatBool")&& ChangeScene.cs.loaded == true)
        {
            boatCoin = (PlayerPrefs.GetInt("BoatBool") != 0);
        }
       */
    }

    


  

    public void AbrirCerrarMochila()
    {        
        if (closedBag)
        {
            panelMiMochila.SetActive(true);
            closedBag = false;
            return;
        }
        if(!closedBag)
        {  panelMiMochila.SetActive(false); 
            closedBag = true;
            return;
        }
    }

    public void SubtractCoins(int i)
    {
        numCoins -= i;
        textCoins.text = "S coins: " + numCoins.ToString();
    }
    public void AddCoin()
    {
        //añade 1 coin y lo muestra en el canvas
        numCoins += 1;
        textCoins.text = "S coins: " + numCoins.ToString();

        //reproduce el audio
        audioSource.clip = audioCoin;
        print("Audio: " + audioCoin.name);
        audioSource.Play();

    }

    public void AddBoatCoin()
    {
        //añade 1 coin y lo muestra en el canvas
        boatCoin = true;
        print("boatcoin");

        particles.parent = boat;

        //reproduce el audio
        audioSource.clip = audioCoin;
        print("Audio: " + audioCoin.name);
        audioSource.Play();

    }


    public void GameOverPanel()
    {
        float addMass = 20;
        float mass;
        print("activo panel pause : " + panelGameOver.name);
        panelGameOver.SetActive(true);
        mochilaButton.SetActive(false);

        GameObject[] newSnowFlakes = new GameObject[15];

        for (int i = 0; i < 15; i++)
        {
            offset = new Vector3(Random.Range(-200, 200), 200 + Random.Range(-200, 200), 0);


            //newSnowflakes = Instantiate(snowflakes, transform.position, transform.rotation);
            newSnowFlakes[i] = Instantiate(snowflakes, panelGameOver.transform.position + offset, panelGameOver.transform.rotation, panelGameOver.transform);
            rbSF = newSnowFlakes[i].GetComponent<Rigidbody2D>();
            mass = rbSF.mass;
            rbSF.mass = mass + addMass;
            
            if (newSnowFlakes[i] != null) { print("okay"); }
        }



        print(newSnowFlakes.Length);
    }

    
}
