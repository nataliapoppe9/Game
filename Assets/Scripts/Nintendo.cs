using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nintendo : MonoBehaviour
{
    // variable estática para acceder al script
    public static Nintendo nm;

    GameObject nintendo;
    public bool tengoGadget=false;

    float velocidadGiro = 100;
    // Start is called before the first frame update
    void Start()
    {
        nintendo = GetComponent<GameObject>();
        nm = this;
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
            Destroy(gameObject);
            tengoGadget = true;

        }
    }
}
