using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    public bool loaded;

    public ItemSprite[] items;

    public Transform container,containerPc;
    public GameObject itemPrefab;

    public List<ItemSprite> obtainedItems;

    [SerializeField] GameObject FF;

    public bool visibleP = false;

    [SerializeField] GameObject parachute;


    public static ItemManager itemMan;

    public List<int> obtainedSprites;
    public List<string> disabled;

    [SerializeField] GameObject gamesGadgetPanel;

  
    private void Start()
    {
       
        itemMan = this;

       /* if (PlayerPrefs.GetInt("FFDesact")==1)
        {
        FF.SetActive(false);
        }*/
     
    }

    public void RestartSprites()
    {
        for(int i=0; i < obtainedSprites.Count; i++)
        {
            SpriteCreator(obtainedSprites[i]);
        }
    }

    public void DisableObjects()
    {
        foreach(string nameGameObj in disabled)
        {
            GameObject.Find(nameGameObj).SetActive(false);
        }
    }

    public void SpriteCreator(int i)
    {
        if (i == 0)
        {
            GameObject ItemClone = Instantiate(itemPrefab, container);

            ItemClone.transform.GetChild(0).GetComponent<Image>().sprite = items[i].imageGadget;
            ItemClone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].nombreGadget;
            ItemClone.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = items[i].detailsGadget;
            ItemClone.GetComponent<Button>().onClick.AddListener(() => gamesGadgetPanel.SetActive(true));
        }
        else if (i != 0)
        {
            GameObject ItemClone = Instantiate(itemPrefab, containerPc);

            ItemClone.transform.GetChild(0).GetComponent<Image>().sprite = items[i].imageGadget;
            ItemClone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].nombreGadget;
            ItemClone.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = items[i].detailsGadget;
          
        }

        if (!obtainedSprites.Contains(i))
        {
            obtainedSprites.Add(i);
        }

        ParachuteCheck();


    }

    public void ParachuteCheck()
    {
        if (ItemManager.itemMan.obtainedSprites.Contains(1) && ItemManager.itemMan.obtainedSprites.Contains(2) && ItemManager.itemMan.obtainedSprites.Contains(3))
        {
            print(" You have 3 pieces");
            parachute.SetActive(true);
            visibleP = true;
        }
        else { parachute.SetActive(false); print("no pieces"); }
    }
}
