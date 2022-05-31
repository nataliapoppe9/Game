using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorMochila : MonoBehaviour
{
    
    public MochilaList baseDatosItemsMochila;

    public GameObject prefabBoton;
    public Transform contentMochila;

    public bool tengoGadGet=false;

    private void Start()
    {
        // PRECARGA BASE DATOS
        foreach(MochilaItem item in baseDatosItemsMochila.itemList)
        {
            GameObject objeto = Instantiate(prefabBoton,contentMochila);
            baseDatosItemsMochila.name = item.name;
            baseDatosItemsMochila.itemList.Add(item);
            Instantiate(prefabBoton, contentMochila);

        }
        
         /*
         foreach (MochilaItem item in baseDatosItemsMochila.itemList) 
        {
            GameObject objeto = Instantiate(prefabBoton, contentMochila);
           //objeto.transform.GetChild(0).GetComponent<Text>().text= item.name;
            objeto.GetComponent<SpriteRenderer>().sprite = item.imagen;
           //objeto.transform.GetChild(1).GetComponent<Button>() = item.price;

        }*/
       // Adquirir();
       
    }

    public void Adquirir(MochilaItem item, GameObject boton)
    {

        baseDatosItemsMochila.name = item.name;
        baseDatosItemsMochila.itemList.Add(item);
        Instantiate(boton, contentMochila);
        
    }
}
