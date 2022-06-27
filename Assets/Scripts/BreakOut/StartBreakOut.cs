using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBreakOut : MonoBehaviour
{
    [SerializeField] GameObject panelGame;
    public void Empezar()
    {
        
        panelGame.SetActive(true);
    }
}
