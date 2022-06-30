using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoatInfoTent : MonoBehaviour
{

    public static bool canUse=false;
    [SerializeField] Transform player,lightPart;
    

    public static float TimerLeft;
    //public bool TimerOn = false;

    public Text TimerTxt;

    private void Start()
    {
       // StartCoroutine(CanUseBoat());
    }

    [SerializeField] GameObject panelBoat,canvasPantalla;
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.name.Contains("Character")))
        {
            panelBoat.SetActive(true);
            canvasPantalla.SetActive(false);
            if (!CanvasManager.gm.boatCoin)
            {
                panelBoat.transform.GetChild(0).gameObject.SetActive(true);
                panelBoat.transform.GetChild(1).gameObject.SetActive(false);
                panelBoat.transform.GetChild(2).gameObject.SetActive(false);
            }

            if (CanvasManager.gm.boatCoin)
            {
                if (canUse)
                {
                    panelBoat.transform.GetChild(0).gameObject.SetActive(false);
                    panelBoat.transform.GetChild(1).gameObject.SetActive(true);
                    panelBoat.transform.GetChild(2).gameObject.SetActive(false);
                }
                else if(!canUse)
                {
                    panelBoat.transform.GetChild(0).gameObject.SetActive(false);
                    panelBoat.transform.GetChild(1).gameObject.SetActive(false);
                    panelBoat.transform.GetChild(2).gameObject.SetActive(true);
                }
               
            }
        }
    }

    private void Update()
    {
        if (CanvasManager.gm.boatCoin)
        {
            print(canUse+", "+TimerLeft);
            if (!canUse)
            {
                TimerLeft -= Time.deltaTime;
                if (TimerLeft > 0)
                {
                    panelBoat.transform.GetChild(2).gameObject.SetActive(true);
                    panelBoat.transform.GetChild(1).gameObject.SetActive(false);
                    
                    UpdateTimer(TimerLeft);
                }
                else
                {
                    print("Time is UP");
                    TimerLeft = 30;
                    canUse = true;
                }
            }
            else if (canUse)
            {
                TimerLeft -= Time.deltaTime;
                if (TimerLeft > 0)
                {
                    panelBoat.transform.GetChild(2).gameObject.SetActive(false);
                    panelBoat.transform.GetChild(1).gameObject.SetActive(true);

                    UpdateTimer(TimerLeft);
                }
                else
                {
                    print("Time is UP");
                    TimerLeft = 30;
                    canUse = false;
                }
            }
          
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = seconds.ToString("00");
    }

    public void MoveToBoat()
    {
        player.position = lightPart.position;
        GameManager.gm.ResumeGame(panelBoat);
    }
   


}
