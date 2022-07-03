using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GotaManager : MonoBehaviour
{
    public static GotaManager gotm;
    //Acceso a PlayerMovement para mover al personaje a la vez que el plano hielo
    //public static PlayerMovement gm;

    public int countMoves;

    [SerializeField] GameObject canvasPlatformGo, canvasPlatformGoBack;
    Transform sueloGota;

    public bool used = false;
   

    [SerializeField] GameObject canvasGota;


    private void Start()
    {

        sueloGota = GetComponent<Transform>();
        countMoves = 0;

        if (PlayerPrefs.HasKey("GotaX") && PlayerPrefs.HasKey("GotaY") && PlayerPrefs.HasKey("GotaZ")&&used)
        {
           // print(PlayerPrefs.GetFloat("GotaX") + " " + PlayerPrefs.GetFloat("GotaY") + " " + PlayerPrefs.GetFloat("GotaZ"));
            sueloGota.position = new Vector3(PlayerPrefs.GetFloat("GotaX"), PlayerPrefs.GetFloat("GotaY"), PlayerPrefs.GetFloat("GotaZ"));

           // countMoves = PlayerPrefs.GetInt("CountGota");
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //si la colision es con character
        if (collision.collider.name.Contains("Character"))
        {
            
            print("countMoves"+ countMoves);
            if (countMoves % 2 ==0) 
            {
                canvasPlatformGo.SetActive(true);

                canvasGota.transform.GetChild(2).GetComponent<Text>().text = "Use platform:";
                canvasGota.transform.GetChild(3).gameObject.SetActive(true);
            }

            else if (countMoves %2!= 0)
            {
                canvasPlatformGoBack.SetActive(true);

               
                canvasGota.transform.GetChild(2).GetComponent<Text>().text = "Use Platform";
                canvasGota.transform.GetChild(3).gameObject.SetActive(false);
                
            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name.Contains("Character"))
        {
           
            ExitText();
            PlayerMovement.pm.platform = false;
            PlayerPrefs.SetFloat("GotaX", sueloGota.position.x);
            PlayerPrefs.SetFloat("GotaY", sueloGota.position.y);
            PlayerPrefs.SetFloat("GotaZ", sueloGota.position.z);
        }


         
        
    }




    /* private void Moving()
     {

         //En cada frame del update se ejecutara moving añadiendo 1 a su posición
         //Se repetirá 80 veces
         if (i < 80)
         {
             //Muevo en z 1 la posicion del hielo.

             transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
             //80veces
             i++;

         }
         else { move = false; }
     }*/

    public void StartPlatform()
    {
        if (CanvasManager.gm.numCoins >= 10)
        {
            CanvasManager.gm.SubtractCoins(10); 
            //move = true;
            StartCoroutine(Moving());
            PlayerMovement.pm.MovePlayerWithPlat();
            PlayerMovement.pm.platform = true;
            canvasPlatformGo.SetActive(false);
            countMoves++;
           
        }
        else
        {
            canvasGota.transform.GetChild(2).GetComponent<Text>().text = "Not enough S-Coins!";
            canvasGota.transform.GetChild(3).gameObject.SetActive(false);
            print("not enough");
        }

           

    }

   /* public void ReturnPlatform()
    {
        if (CanvasManager.gm.numCoins >= 11)
        {
            CanvasManager.gm.SubtractCoins(11);
            StartCoroutine(GoingBack());
            PlayerMovement.pm.GoBackWithPlatform();
            PlayerMovement.pm.platform = true;
            canvasPlatformGoBack.SetActive(false);
            countMoves++;
        }
        else
        {
            print("not enough");
        }

        

    }

    public void MovePlat()
    {
        for (int i = 0; i < 30; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
        }
    }*/

    IEnumerator Moving()
    {
        
        for (int i = 0; i < 30; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
            yield return new WaitForSeconds(0.07f);
        }

        PlayerPrefs.SetFloat("GotaX", sueloGota.position.x);
        PlayerPrefs.SetFloat("GotaY", sueloGota.position.y);
        PlayerPrefs.SetFloat("GotaZ", sueloGota.position.z);

    }

    IEnumerator GoingBack()
    {
        for (int i = 0; i < 30; i++)
        {
            print("platfMoving");  
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
            yield return new WaitForSeconds(0.07f);
        }

        PlayerPrefs.SetFloat("GotaX", sueloGota.position.x);
        PlayerPrefs.SetFloat("GotaY", sueloGota.position.y);
        PlayerPrefs.SetFloat("GotaZ", sueloGota.position.z);

    }
  /*  public void GoBack()
    {

        for(int i=0; i< 80; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }
        
    }*/


    public void ExitText()
    {
        canvasPlatformGoBack.SetActive(false);
        canvasPlatformGo.SetActive(false);
    }
}
