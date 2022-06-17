using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFCineManager : MonoBehaviour
{
    [SerializeField] private GameObject rotation;
    [SerializeField] private GameObject sphere;

   public void StopRotation()
    {
        rotation.GetComponent<RotateForceCamera>().enabled = false;
    }

    public void DestroySphere()
    {
        Destroy(sphere.gameObject);
    }
}
