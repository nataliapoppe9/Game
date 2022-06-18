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

    public PlayableDirector timeLineForce;


    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (amoniteCounter < 5)
        {
            NeedAmonites(); 
        }
        else
        {
            DeactivateForceField();
            
        }
    }

    void DeactivateForceField()
    {
        amoniteCountPanel.SetActive(false);
        // anim.SetTrigger("DeactivateForce");
        Amonite.am.MoveAroundForce(transform);

        // reproducir cinemática


        timeLineForce.gameObject.SetActive(true);
        timeLineForce.Play();
    }

    void NeedAmonites()
    {
        panel.SetActive(true);
        amoniteCountPanel.GetComponentInChildren<Text>().text = amoniteCounter.ToString() + " / 5";
    }

    public void ClosePanel()
    {
       // if(panel.active==true)
        panel.SetActive(false);
        amoniteCountPanel.SetActive(true);
    }

    
    private void FixedUpdate()
    {
        amoniteCounter  = Amonite.am.startedNum.Count;
        amoniteCountPanel.GetComponentInChildren<Text>().text = amoniteCounter.ToString() + " / 5";

    }
}
