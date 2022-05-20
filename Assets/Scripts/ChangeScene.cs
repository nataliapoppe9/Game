using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Funcion que llamo desde el panel de inicio con NewGame
    //Cuando llamo a la funcion en el boton del canvas, INTRODUZCO PARAMETRO nameScene alli
    public void NewScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene); // cargar escena
    }
}
