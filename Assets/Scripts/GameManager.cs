using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static bool gameIsPaused;

    [SerializeField] GameObject panelPause, panelSaved, panelBoat;
    [SerializeField] GameObject canvasPantalla;
    [SerializeField] GameObject hint;

    int rand;
    int doneRandom;

    [SerializeField] List<string> hints;

    public PlayableDirector timeLineEntry;
    bool enabled;

    //REVISARLO
    //A�ADIR UNA SE�AL EN TIMELINE PARA ENABLED == FALSE CUADNO ACABA
    private void Awake()
    {
        while (timeLineEntry.enabled==true) {
            if (Input.GetKey(KeyCode.Return) && enabled)
            {
                timeLineEntry.Stop();
                enabled = false;
            }
            if (Input.GetKey(KeyCode.Return) && !enabled)
            {
                timeLineEntry.Play();
                enabled = true;
            }
        }
    }

   
    private void Start()
    {
        gm = this;

        

        hints.Add("Jump on mushrooms");
        hints.Add("Save Game from Time 2 Time");
        hints.Add("S-Coins will take you far");
        hints.Add("Each journey is different");
        hints.Add("Don't leave anything behind..");
        hints.Add("Is your Boat Token ready?");
        hints.Add("Boat Time info at Tent");
        hints.Add("Check backpack");
        hints.Add("Amonites seem friendly, don't they?");


        
        rand = Random.Range(0, hints.Count);
        hint.GetComponent<Text>().text=hints[rand] ; 
            

    }

    public void ChangeHint()
    {
        doneRandom = rand;
        rand = Random.Range(0, hints.Count);
        print("doneRand"+doneRandom+"rand"+rand);

        while (rand==doneRandom)
        {
            rand = Random.Range(0, hints.Count);
        }

        print("AFTERCHECK");
        print(doneRandom + "   " + rand);
        hint.GetComponent<Text>().text = hints[rand];
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            print("paused");
            Time.timeScale = 0f;
            panelPause.SetActive(true);
            canvasPantalla.SetActive(false);

            gameIsPaused = true;
                 
        }
    }

   
    public void ResumeGame(GameObject panel)
    {
        panel.SetActive(false);
        canvasPantalla.SetActive(true);
        gameIsPaused = false;
        Time.timeScale = 1;
    }

   
   

    public void SaveAplicationGame()
    {

        SaveGame();
        print("activoSaved");
        panelSaved.SetActive(true);
        panelPause.SetActive(false);
        //Time.timeScale=0;         
        StartCoroutine(DesactivarPanel(panelSaved));
    }

    IEnumerator DesactivarPanel(GameObject panel)
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(1);
        print("off");
        
        panel.SetActive(false);
        canvasPantalla.SetActive(true);
       
       

    }

    

    void SaveGame()
    {
        if (!PlayerMovement.pm.platform)
        {
            
            PlayerPrefs.SetInt("numCoins", CanvasManager.gm.numCoins);
            PlayerPrefs.SetFloat("PositionX", PlayerMovement.pm.transform.position.x);
            PlayerPrefs.SetFloat("PositionY", PlayerMovement.pm.transform.position.y);
            PlayerPrefs.SetFloat("PositionZ", PlayerMovement.pm.transform.position.z);
            PlayerPrefs.SetFloat("RotX", PlayerMovement.pm.transform.rotation.eulerAngles.x);
            PlayerPrefs.SetFloat("RotY", PlayerMovement.pm.transform.rotation.eulerAngles.y);
            PlayerPrefs.SetFloat("RotZ", PlayerMovement.pm.transform.rotation.eulerAngles.z);
            PlayerPrefs.SetInt("BoatBool", (CanvasManager.gm.boatCoin ? 1 : 0));

            // PlayerPrefs.SetInt("CountGota", GotaManager.gotm.countMoves);


            // PlayerPrefs.Save(); No hace falta
            print("GAME SAVED");

        }
    }



}