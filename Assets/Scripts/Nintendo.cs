using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nintendo : MonoBehaviour
{
    // variable estática para acceder al script
   public static Nintendo nm;

 
    // public bool tengoGadget=false;
    //MochilaItem gadgetItem;
   // public GameObject gadgetSpritePrefab;
    public GameObject shine;

    float velocidadGiro = 100;
    // Start is called before the first frame update
    void Start()
    {
        nm = this;
        //gadgetItem =GetComponentInChildren<MochilaItem>();
    }

    // Update is called once per frame
    void Update()

    {
        transform.Rotate(0, 0, velocidadGiro * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("He colisionado por primera vez");
            
            ItemManager.itemMan.SpriteCreator();
          //  tengoGadget = true;
          // print( ItemManager.itemMan.SpriteCreator(itemPrefab));

            Destroy(gameObject);
        }
    }
}
