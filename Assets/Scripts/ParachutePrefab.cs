using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParachutePrefab : MonoBehaviour
{
    public static ParachutePrefab ppm;

    
    PlayerMovement parachutePM;
    GameObject player;

    private void Start()
    {
        ppm = this;
        //0 : nintendo
        //1 : Torre
        //2 : teclado y raton
        //3 : Pantalla

       

    }

    public void ParachuteCheck()
    {
        if (ItemManager.itemMan.obtainedSprites.Contains(1) && ItemManager.itemMan.obtainedSprites.Contains(2) && ItemManager.itemMan.obtainedSprites.Contains(3))
        {
            print(" You have 3 pieces");
            GetComponent<GameObject>().SetActive(true);
        }
        else { GetComponent<GameObject>().SetActive(false); print("no pieces"); }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

           

            /*parachutePM = PlayerMovement.pm;
            player = parachutePM.gameObject;
            UseParachute();*/

            GameManager.gm.parachuteInfo.transform.GetChild(3).GetComponent<Text>().text = "Buy parachute";

            GameManager.gm.parachuteInfo.transform.GetChild(4).GetComponent<Text>().text = "20 scoins";
            GameManager.gm.parachuteInfo.transform.GetChild(4).GetComponent<Text>().color = Color.white;

            GameManager.gm.parachuteInfo.SetActive(true);
            GameManager.gm.canvasPantalla.SetActive(false);
            
        }
    }

   /* public void UseParachute()
    {
        parachutePM.usingParachute = true;

        Destroy(gameObject);
    }
   */
}
