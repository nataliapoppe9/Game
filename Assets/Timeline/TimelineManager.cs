using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineManager : MonoBehaviour
{
    public PlayableDirector playableDirector;
    bool start = false;
    public void PlayMyDirector()
    {
       
        playableDirector.GetComponent<TimelineClip>();
    }

    private void Awake()
    {
        start = false;
        if (start)
        {
            PlayMyDirector();
        }
    }
}
