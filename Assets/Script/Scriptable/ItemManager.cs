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

    public Transform container;
    public GameObject itemPrefab;

    public List<ItemSprite> obtainedItems;

    [SerializeField] GameObject FF;
    

    public static ItemManager itemMan;

    public List<int> obtainedSprites;
    public List<GameObject> disabled;

    [SerializeField] GameObject gamesGadgetPanel;

  
    private void Start()
    {
       
        itemMan = this;


        /* if (ChangeScene.cs.saved)
         {


             if (PlayerPrefs.GetInt("FFDesact")==1)
             {
                 FF.SetActive(false);
             }

        */
     
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
        foreach(GameObject gameObj in disabled)
        {
            gameObj.SetActive(false);
        }
    }

    public void SpriteCreator(int i)
    {
        GameObject ItemClone = Instantiate(itemPrefab, container);

        ItemClone.transform.GetChild(0).GetComponent<Image>().sprite = items[i].imageGadget;
        ItemClone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].nombreGadget;
        ItemClone.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = items[i].detailsGadget;
        ItemClone.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = items[i].priceGadget.ToString();
       
        if (!obtainedSprites.Contains(i))
        {
            obtainedSprites.Add(i);
        }

        if (i == 0)
        {
            ItemClone.GetComponent<Button>().onClick.AddListener(() => gamesGadgetPanel.SetActive(true)) ;
        }

    }
}
