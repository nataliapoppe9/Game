using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmoniteForPrefab : MonoBehaviour
{
    [SerializeField] int numAmonitFollow=0;
      private void OnCollisionEnter(Collision collision)
     {
        if (collision.gameObject.CompareTag("Player"))
        {
           // print("he colisionnado con amonite");
            switch (transform.name)
            {
                case "Amonite0":
                    Amonite.am.StartAmonite(0);
                    numAmonitFollow++;
                    break;
                case "Amonite1":
                    Amonite.am.StartAmonite(1);
                    numAmonitFollow++;
                    break;
                case "Amonite2":
                    Amonite.am.StartAmonite(2);
                    numAmonitFollow++;
                    break;
                case "Amonite3":
                    Amonite.am.StartAmonite(3);
                    numAmonitFollow++;
                    break;
                case "Amonite4":
                    Amonite.am.StartAmonite(4);
                    numAmonitFollow++;
                    break;

            }
        }
    }

}
