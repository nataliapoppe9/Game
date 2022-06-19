using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoatInfoTent : MonoBehaviour
{

    public bool canUse;

    [SerializeField] GameObject panelBoat,canvasPantalla;
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.name.Contains("Character")))
        {
            panelBoat.SetActive(true);
            canvasPantalla.SetActive(false);
            if (!CanvasManager.gm.boatCoin)
            {
                //panelBoat.SetActive(true);
            }

            if (CanvasManager.gm.boatCoin)
            {

                panelBoat.transform.GetChild(0).gameObject.SetActive(false);
                panelBoat.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);

                if (canUse)
                {
                    panelBoat.transform.GetChild(2).gameObject.SetActive(true);
                    //PrintSec();

                    // Invoke o DObleCorrutina o que para mostrar los segundos que quedan?
                }
                if (!canUse)
                {
                    panelBoat.transform.GetChild(3).gameObject.SetActive(true);
                   // PrintSec();
                }
            }
        }
    }

    private void Update()
    {
        StartCoroutine(CantUseBoat());
       
    }

    IEnumerator CanUseBoat()
    {
        canUse = true;
        yield return new WaitForSeconds(30);
        
    }

    IEnumerator CantUseBoat()
    {
        canUse = false;
        yield return new WaitForSeconds(30);

    }

    IEnumerator PrintSec()
    {
        panelBoat.transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = Time.deltaTime.ToString("00");

        panelBoat.transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = Time.deltaTime.ToString("00");
        yield return new WaitForSeconds(1);
        
    }
}
