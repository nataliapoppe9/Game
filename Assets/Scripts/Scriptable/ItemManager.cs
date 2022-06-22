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

    public List<int> obtainedSprites;
    public List<GameObject> disabled;

    private void Start()
    {
       
        itemMan = this;

        if (ChangeScene.cs.loaded)
        {
            print("disable destroyed Items");

            foreach(GameObject gameObj in disabled)
            {
                gameObj.SetActive(false);
            }


            print("Loaded BackPack");
           

            for (int i = 0; i < items.Length; i++)
            {
                GameObject objeto = Instantiate(itemPrefab, container);
                objeto.transform.GetChild(0).GetComponent<Image>().sprite = items[i].imageGadget;

                objeto.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].nombreGadget;
                objeto.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = items[i].detailsGadget;
                objeto.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = items[i].priceGadget.ToString();


                //ERROR NO EXISTE ESE BUTTON
                //objeto.GetComponent<Button>().onClick.AddListener(() => Vender(i, objeto));
            }          
        }
    }

    // NO SE SI ESTA BIEN
    public void Vender(int i, GameObject obj)
    {
        CanvasManager.gm.numCoins += items[i].priceGadget; // incremento mi saldo con lo que he vendido
        obtainedSprites.Remove(i);
       
        Destroy(obj);
    }


    public void SpriteCreator(int i)
    {
        GameObject ItemClone = Instantiate(itemPrefab, container);

        ItemClone.transform.GetChild(0).GetComponent<Image>().sprite = items[i].imageGadget;
        ItemClone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].nombreGadget;
        ItemClone.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = items[i].detailsGadget;
        ItemClone.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = items[i].priceGadget.ToString();
        obtainedSprites.Add(i);
        
    }
}
