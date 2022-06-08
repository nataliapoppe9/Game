using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotaManager : MonoBehaviour
{
    //Acceso a PlayerMovement para mover al personaje a la vez que el plano hielo
    public static PlayerMovement gm;

    public int countMoves;

    [SerializeField] GameObject canvasPlatformGo, canvasPlatformGoBack;
    Transform sueloGota;

    private void Start()
    {
        sueloGota = GetComponent<Transform>();
        countMoves = 0;
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
                
            }

            else if (countMoves %2!= 0)
            {
                canvasPlatformGoBack.SetActive(true);
             
            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name.Contains("Character"))
        {
            //activo move en update

            ExitText();
            PlayerMovement.pm.platform = false;
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
            CanvasManager.gm.numCoins -= 10;
            //move = true;
            StartCoroutine(Moving());
            PlayerMovement.pm.MovePlayerWithPlat();
            PlayerMovement.pm.platform = true;
            canvasPlatformGo.SetActive(false);
            countMoves++;
        }
        else
        {
            //AVISAR QUE NO HAY SUFICIENTE
            print("not enough");
        }

           

    }

    public void ReturnPlatform()
    {
        if(CanvasManager.gm.numCoins >=10)
        CanvasManager.gm.numCoins -= 10;
        else
        {
            print("not enough");
        }

        StartCoroutine(GoingBack());
        PlayerMovement.pm.GoBackWithPlatform();
        PlayerMovement.pm.platform = true;
        canvasPlatformGoBack.SetActive(false);
        countMoves++;

    }

  /*  public void MovePlat()
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
        
    }

    IEnumerator GoingBack()
    {
        for (int i = 0; i < 30; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
            yield return new WaitForSeconds(0.07f);
        }
    }
    public void GoBack()
    {

        for(int i=0; i< 80; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }
    }


    public void ExitText()
    {
        canvasPlatformGoBack.SetActive(false);
        canvasPlatformGo.SetActive(false);
    }
}
