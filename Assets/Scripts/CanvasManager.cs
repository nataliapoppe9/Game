using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager gm;

    AudioSource audioSource;
    [SerializeField] AudioClip audioCoin;

    //Rewards ¿MEjor en GameManager?
    public int numCoins = 0;
    Text textCoins;
    private void Start()
    {
        //cojo este script para poder ser accedido desde otro
        gm = this;

        textCoins = GameObject.Find("TextScore").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();

    }


    public void AddCoin() // mejor en game manager???
    {
        numCoins += 1;
        textCoins.text = "S coins: " + numCoins.ToString();

        // print(numCoins);
        audioSource.clip = audioCoin;
        print("Audio: " + audioCoin.name);
        audioSource.Play();

        // GetComponent<AudioSource>().Play();
    }
}
