using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    Vector2 moveDirection;
    Vector2 currentVelocity;
    GameManagerBreakOut gameManager;

    [SerializeField] float speed = 5;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //rigidbody2D.velocity = Vector2.up * speed;
        gameManager = FindObjectOfType<GameManagerBreakOut>();
    }
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        currentVelocity = rb2D.velocity;
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);
        rb2D.velocity = moveDirection;
        if (collision.transform.CompareTag("DeathLimit"))
        {
            Debug.Log("Colision con el límite bajo");
            if (gameManager != null)
            {
                gameManager.PlayerLives--;
            
            }
        }

    }

    public void LaunchBall()
    {
        transform.SetParent(null);
        rb2D.velocity = Vector2.up * speed;
    }

    public void ResetBall()
    {
        rb2D.velocity = Vector3.zero;
        Transform paddle = GameObject.Find("Paddle").transform;
        transform.SetParent(paddle);
        Vector2 ballPosition = paddle.position;
        ballPosition.y += 0.6f;
        transform.position = ballPosition;
        gameManager.BallOnPlay = false;
    }
} 
