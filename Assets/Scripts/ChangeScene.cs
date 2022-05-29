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

    public void NewScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene); // cargar escena
    }

    public void LoadMyScene(string nameMyScene)
    {
        loaded = true;
        SceneManager.LoadScene(nameMyScene);
               
    }
}
