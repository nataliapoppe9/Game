using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{

    public ItemSprite[] items;
    public Transform container;
    public GameObject itemPrefab;
    

    public static ItemManager itemMan;

    
    private void Start()
    {
       
        itemMan = this;
        // SpriteCreator();
        if (ChangeScene.cs.loaded && Nintendo.nm.obtained)
        {
            print("loadedNintendo");
           //HELP
        }
    }


    public void SpriteCreator(int i)
    {

                
                GameObject ItemClone = Instantiate(itemPrefab);
                ItemClone.transform.SetParent(container);

                ItemClone.transform.GetChild(0).GetComponent<Image>().sprite = items[i].imageGadget;
                ItemClone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].nombreGadget;
                ItemClone.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = items[i].detailsGadget;
            
        
    }
}
