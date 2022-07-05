using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFCineManager : MonoBehaviour
{
    [SerializeField] private GameObject rotation;
    [SerializeField] private GameObject sphere;
    [SerializeField] AudioSource audioGamePlay, audioForceField;

   public void StopRotation()
    {
        rotation.GetComponent<RotateForceCamera>().enabled = false;
    }

    public void DestroySphere()
    {
        sphere.gameObject.SetActive(false);
        ItemManager.itemMan.disabled.Add(sphere.gameObject.name);
    }

    public void StartAudioFF()
    {
        audioGamePlay.Stop();
        audioForceField.Play();
    }

    public void EndAudioFF()
    {
        audioGamePlay.Play();
        audioForceField.Stop();
    }
}
