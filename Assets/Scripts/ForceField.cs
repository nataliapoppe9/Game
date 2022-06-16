using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ForceField : MonoBehaviour
{
    [SerializeField] GameObject panel, amoniteCountPanel;
    int amoniteCounter;
    public PlayableDirector playableDirector;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (amoniteCounter < 5)
        {
            panel.SetActive(true);
            amoniteCountPanel.SetActive(true);
            amoniteCountPanel.GetComponentInChildren<Text>().text = amoniteCounter.ToString() + " / 5";
        }
        else
        {
            // grabar y  reproducir cinemática
            amoniteCountPanel.SetActive(false);
            anim.SetTrigger("DeactivateForce");
            Amonite.am.MoveAroundForce(transform);
          //  playableDirector.GetComponent<TimelineClip>().start=0;
           // Destroy(gameObject);
        }
    }

    public void ClosePanel()
    {
       // if(panel.active==true)
        panel.SetActive(false);
    }

    
    private void Update()
    {
        amoniteCounter  = Amonite.am.startedNum.Count;
        amoniteCountPanel.GetComponentInChildren<Text>().text = amoniteCounter.ToString() + " / 5";

    }
}
