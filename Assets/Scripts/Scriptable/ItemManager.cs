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
    /*
    public TextMeshProUGUI textNameItem;
    public TextMeshProUGUI textPriceItem;
    public Image imageItemUI;

    public ItemSprite item;

   
    GameObject ItemClone;
   //*/ 

    private void Start()
    {
        /*
        imageItemUI.sprite = item.imageGadget;
        imageItemUI.preserveAspect = true;

        textNameItem.text = item.nombreGadget;
        textPriceItem.text = item.priceGarget.ToString();
        */
        itemMan = this;
       // SpriteCreator();
    }


    public void SpriteCreator()
    {

        for (int i = 0; i < items.Length; i++)
        {
            GameObject ItemClone = Instantiate(itemPrefab);
            ItemClone.transform.SetParent(container);

            ItemClone.transform.GetChild(0).GetComponent<Image>().sprite = items[i].imageGadget;
            ItemClone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].nombreGadget;
            ItemClone.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = items[i].priceGarget.ToString();

        }
    }
}
