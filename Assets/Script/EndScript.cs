using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    [SerializeField] GameObject panelWin;
    private void OnCollisionEnter(Collision collision)
    {
        print("collision");
        if (collision.collider.name == "Character")
        {
                panelWin.SetActive(true);
        }
    }
}
