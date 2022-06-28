using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject panelMenu, panelGame;
    public void StartGame()
    {
        panelMenu.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
    }
}
