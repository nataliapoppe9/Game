using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private GameObject text;
    
    public void RevealText()
    {
        text.SetActive(true);
    }


}
