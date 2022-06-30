using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float speed = 15;
    [SerializeField] float xLimit = 6.75f;

    GameManagerBreakOut gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManagerBreakOut>();
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.D) && transform.position.x < xLimit)
        {
            transform.position += Time.deltaTime * speed * Vector3.right;
        }
        else if (Input.GetKey(KeyCode.A) && transform.position.x > -xLimit)
        {
            transform.position += Time.deltaTime * speed * Vector3.left;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(gameManager.BallOnPlay == false)
            {
                gameManager.BallOnPlay = true;
            }
            if(gameManager.GameStarted == false)
            {
                gameManager.GameStarted = true;
            }
        }
        if(transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }

    }
}
