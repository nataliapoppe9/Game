using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditLinks : MonoBehaviour
{
    public void OpenWeb()
    {
        Application.OpenURL("www.personaldosis.xyz");
    }

    public void OpenInsta()
    {
        Application.OpenURL("www.instagram.com/personaldosis");
    }
}
