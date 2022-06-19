using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static bool gameIsPaused;

    [SerializeField] GameObject panelPause, panelSaved, panelBoat;
    [SerializeField] GameObject canvasPantalla;
    [SerializeField] GameObject hint;

    int random;

    [SerializeField] List<string> hints;
    private void Start()
    {
        gm = this;

        

        hints.Add("Jump on mushrooms");
        hints.Add("Save Game from Time 2 Time");
        hints.Add("S-Coins will take you far");
        hints.Add("Comming back costs more than Going");
        hints.Add("Don't leave anything behind..");
        hints.Add("Do you have your Boat Token ready?");
        hints.Add("BoatTimetable stored on Nintendo");
        //RECUERDA: hacer que el barco salga solo cada minuto durante medio minuto
        hints.Add("Check your backpack");
        hints.Add("Amonites seem friendly, don't they?");

        random = Random.Range(0, hints.Count);
        
        hint.GetComponent<Text>().text=hints[random] ; 
            //""text=hints[random];

    }

    public void ChangeHint()
    {
        random = Random.Range(0, hints.Count);
        hint.GetComponent<Text>().text = hints[random];
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
            // PlayerPrefs.Save(); No hace falta
            print("GAME SAVED");
        }
    }



}
