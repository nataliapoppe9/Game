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

    Vector3 posicion;

    
    public int numCoins = 0;
    Text textCoins;
    private void Start()
    {
        //cojo este script para poder ser accedido desde otro
        gm = this;

        textCoins = GameObject.Find("TextScore").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();

        print(ChangeScene.cs.loaded + "CARGARON LOS COINS");
        if (PlayerPrefs.HasKey("numCoins") && ChangeScene.cs.loaded==true)
        {
            numCoins = PlayerPrefs.GetInt("numCoins"); // Cuando abrimos partida nueva recuperamos
            print(numCoins);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
    }


    public void AddCoin() 
    {
        numCoins += 1;
        textCoins.text = "S coins: " + numCoins.ToString();

        // print(numCoins);
        audioSource.clip = audioCoin;
        print("Audio: " + audioCoin.name);
        audioSource.Play();

        // GetComponent<AudioSource>().Play();
    }

    public void GameOverPanel()
    {
        GameObject[] newSnowFlakes={null,null,null,null,null,null,null,null,null,null,null,null,null,null,null};
        panelGameOver.SetActive(true);

        
            for (int i = 0; i < 15; i++)
        {
            
            offset = new Vector3(Random.Range(-400, 400), 220 + Random.Range(0, 30), 0);


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
        PlayerPrefs.SetInt("numCoins",numCoins);
        posicion = PlayerMovement.pm.GivePosition();
        PlayerPrefs.SetFloat("PositionX",posicion.x);
        PlayerPrefs.SetFloat("PositionY", posicion.y);
        PlayerPrefs.SetFloat("PositionZ", posicion.z);
        PlayerPrefs.Save();
        print(posicion);
    }
}
