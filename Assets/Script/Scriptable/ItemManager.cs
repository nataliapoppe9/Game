using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{

    public ItemSprite[] items;

    //public List<ItemSprite> items;
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
       
        if (ChangeScene.cs.loaded)
        {
            if (PlayerPrefs.GetInt("Once") == 1) 
            {
                Amonite.am.SpawnAmonite();
                for(int i=0; i<PlayerPrefs.GetInt("AmonitesQMeSiguen"); i++)
                {
                    Amonite.am.start = true;
                    Amonite.am.OneFollowsPlayer(i);
                }
            }

            

            if (PlayerPrefs.GetInt("FFDesact")==1)
            {
                FF.SetActive(false);
            }
           

            print("disable destroyed Items" + disabled.Count);

            foreach(GameObject gameObj in disabled)
            {
                gameObj.SetActive(false);
            }


            print("Loaded BackPack");

            print(obtainedItems.Count);
            
            for (int i = 0; i < items.Length; i++)
            {
                //print(obtainedItems[i].nombreGadget);

                // SpriteCreator(obtainedSprites[i]);


                GameObject objeto = Instantiate(itemPrefab, container);
                objeto.transform.GetChild(0).GetComponent<Image>().sprite = items[i].imageGadget;
                objeto.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].nombreGadget;
                objeto.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = items[i].detailsGadget;
                objeto.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = items[i].priceGadget.ToString();

                /* GameObject objeto = Instantiate(itemPrefab, container);
                 objeto.transform.GetChild(0).GetComponent<Image>().sprite = items[obtainedSprites[i]].imageGadget;
                 objeto.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[obtainedSprites[i]].nombreGadget;
                 objeto.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = items[obtainedSprites[i]].detailsGadget;
                 objeto.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = items[obtainedSprites[i]].priceGadget.ToString();*/



            }          
        }
    }



    public void SpriteCreator(int i)
    {
        GameObject ItemClone = Instantiate(itemPrefab, container);

        ItemClone.transform.GetChild(0).GetComponent<Image>().sprite = items[i].imageGadget;
        ItemClone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].nombreGadget;
        ItemClone.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = items[i].detailsGadget;
        ItemClone.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = items[i].priceGadget.ToString();
        obtainedSprites.Add(i);
        

        if (i == 0)
        {
            ItemClone.GetComponent<Button>().onClick.AddListener(() => gamesGadgetPanel.SetActive(true)) ;
        }

    }
}
