using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //GameObject gameManagerObj;
    GameManagerBreakOut gameManager;
    [SerializeField] GameObject explosionPrefab;

    private void Start()
    {
        /*gameManagerObj = GameObject.Find("GameManager");
        if (gameManagerObj == null)
        {
            Debug.Log("Objeto no encontrado");
        }
        else
        {
            gameManager = gameManagerObj.GetComponent<GameManager>();
            gameManager.bricksOnLevel++;
        }*/

        gameManager = FindObjectOfType<GameManagerBreakOut>();
        if(gameManager != null)
        {
            gameManager.BricksOnLevel++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
       if(gameManager != null)
        {
            gameManager.BricksOnLevel--;
        }
        Destroy(gameObject);
    }
}
