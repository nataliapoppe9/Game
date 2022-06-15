using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceField : MonoBehaviour
{
    [SerializeField] GameObject panel, amoniteCountPanel;
    int amoniteCounter;
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
            Destroy(gameObject);
        }
    }

    public void ClosePanel()
    {
        if(panel.active)
        panel.SetActive(false);
    }

    
    private void Update()
    {
        amoniteCounter  = Amonite.am.startedNum.Count;
        amoniteCountPanel.GetComponentInChildren<Text>().text = amoniteCounter.ToString() + " / 5";

    }
}
