using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager gm;

    AudioSource audioSource;
    [SerializeField] AudioClip audioCoin;

    [SerializeField] GameObject panelSaved;

    [SerializeField] GameObject panelGameOver;
    [SerializeField] GameObject snowflakes;
    // GameObject[] newSnowflakes;
    private Vector3 offset;
    Rigidbody2D rbSF;

    //Variables Mochila
    [SerializeField] GameObject mochilaButton;
    public GameObject panelMiMochila;
    bool closedBag = true;

    public int numCoins = 0;
    Text textCoins;
    private void Start()
    {
        //cojo este script para poder ser accedido desde otro
        gm = this;

        //inicializo textCoins y audiosource
        textCoins = GameObject.Find("TextScore").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();


        //print(ChangeScene.cs.loaded + "CARGARON LOS COINS");

        // Si he guardado partida y tengo almacenado el numero de coins
        if (PlayerPrefs.HasKey("numCoins") && ChangeScene.cs.loaded == true)
        {
            numCoins = PlayerPrefs.GetInt("numCoins"); // Cuando abrimos partida nueva recuperamos
            textCoins.text = "S coins: " + numCoins.ToString();
            print(numCoins);
        }

    }

    private void Update()
    {
        //Guardar con la tecla S
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
            panelSaved.SetActive(true);
           //Time.timeScale=0;         
           StartCoroutine(DesactivarPanel(panelSaved));
        }
    }


    IEnumerator DesactivarPanel(GameObject panel)
    {
        print("off");
        //Time.timeScale = 1;
        yield return new WaitForSeconds(0.7f);
        panel.SetActive(false);
       
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


    // INICIALIZAR VECTOR AYUDAAAA
    public void GameOverPanel()
    {
        GameObject[] newSnowFlakes = new GameObject[15];
        panelGameOver.SetActive(true);
        mochilaButton.SetActive(false);
        
        for (int i = 0; i < 15; i++)
        {
            offset = new Vector3(Random.Range(-200, 200), 120 + Random.Range(0, 30), 0);


            //newSnowflakes = Instantiate(snowflakes, transform.position, transform.rotation);
            newSnowFlakes[i] = Instantiate(snowflakes, panelGameOver.transform.position + offset, panelGameOver.transform.rotation, panelGameOver.transform);
            rbSF = newSnowFlakes[i].GetComponent<Rigidbody2D>();
            rbSF.velocity = Random.Range(5, 10) * (-Vector3.up);
            if (newSnowFlakes[i] != null) { print("okay"); }
        }



        print(newSnowFlakes.Length);
    }

    void SaveGame()
    {
        if (!PlayerMovement.pm.platform)
        {
            PlayerPrefs.SetInt("numCoins", numCoins);
            PlayerPrefs.SetFloat("PositionX", PlayerMovement.pm.transform.position.x);
            PlayerPrefs.SetFloat("PositionY", PlayerMovement.pm.transform.position.y);
            PlayerPrefs.SetFloat("PositionZ", PlayerMovement.pm.transform.position.z);
            PlayerPrefs.SetFloat("RotX", PlayerMovement.pm.transform.rotation.eulerAngles.x);
            PlayerPrefs.SetFloat("RotY", PlayerMovement.pm.transform.rotation.eulerAngles.y);
            PlayerPrefs.SetFloat("RotZ", PlayerMovement.pm.transform.rotation.eulerAngles.z);
            // PlayerPrefs.Save(); No hace falta
            print("GAME SAVED");
        }
    }
}
