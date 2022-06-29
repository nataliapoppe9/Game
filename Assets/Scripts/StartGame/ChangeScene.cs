using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene cs;

    // Funcion que llamo desde el panel de inicio con NewGame
    //Cuando llamo a la funcion en el boton del canvas, INTRODUZCO PARAMETRO nameScene alli
    public bool loaded;
    


    private void Start()
    {
        cs = this;
       
    }

    public void CheckLoad()
    {
        print(PlayerPrefs.GetInt("SavedGame"));

        if (PlayerPrefs.GetInt("SavedGame") ==0)
        {
            loaded = false;
            print("NO HAY PARTIDA");
        }
        else { loaded = true; }

        print(loaded);
    }

    public void NewScene(string nameScene)
    {
        loaded = false;
        SceneManager.LoadScene(nameScene); // cargar escena
    }

    public void LoadMyScene(string nameMyScene)
    {
        CheckLoad();
        SceneManager.LoadScene(nameMyScene);

        
    }
}
