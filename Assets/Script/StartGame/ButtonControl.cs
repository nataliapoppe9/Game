using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{

    private void Start()
    {
        if (PlayerPrefs.GetInt("SavedGame")== 1)
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
