using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{

    public static IntroManager introMan;
    [SerializeField] private GameObject text;
    [SerializeField] AudioSource audioEntrance, audioGamePlay;

    private void Awake()
    {
        introMan = this;
    }
    public void RevealText()
    {
        text.SetActive(true);
    }

    public void ChangeAudio()
    {
        if (audioEntrance.isPlaying)
        {
            audioEntrance.Stop();
            audioGamePlay.Play();
        }
        
    }
}
