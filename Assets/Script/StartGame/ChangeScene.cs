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
    public bool load;

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
        load = true;
        SceneManager.LoadScene(nameMyScene);
        //vid.GetComponent<VideoPlayer>().Stop();
    }

}
