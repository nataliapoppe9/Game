using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene cs;

    // Funcion que llamo desde el panel de inicio con NewGame
    //Cuando llamo a la funcion en el boton del canvas, INTRODUZCO PARAMETRO nameScene alli
    public bool saved=false;
    public bool loaded=false;

  //  public GameObject vid;
   
    
    


    private void Start()
    {
        cs = this;
    }

    public void CheckSaved()
    {
        if (saved) { print("saved");  }
        else if (!saved) { print("no saved Game");  }
    }


    public void NewScene(string nameScene)
    {
        
        SceneManager.LoadScene(nameScene); // cargar escena
       // vid.GetComponent<VideoPlayer>().Stop();
    }

    public void LoadedScene(string nameMyScene)
    {
        loaded = true;
        // NOO LO PONGAS MAS!! GameManager.gm.Load(); 
        // con load controlo si hago load en start de game manager
        SceneManager.LoadScene(nameMyScene);
        
    }


    public void OpenGame(string myGame)
    {
        SceneManager.LoadScene(myGame);
    }


}
