using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBreakOut : MonoBehaviour
{
    [SerializeField] byte bricksOnLevel;
    float gameTime;
    public byte BricksOnLevel
    {
        get => bricksOnLevel;
        set
        {
            bricksOnLevel = value;
            if (bricksOnLevel == 0)
            {
                Debug.Log("Has ganado el nivel");
                Destroy(GameObject.Find("Ball"));
                gameTime = Time.time * gameTime;
                FindObjectOfType<UIController>().ActivarWinPanel(gameTime);

            }

        }
    }
    [SerializeField] byte playerLives = 3;

    public byte PlayerLives
    {
        get => playerLives;
        set
        {
            playerLives = value;
            if (playerLives == 0)
            {
                Debug.Log("Has muerto");
                Destroy(GameObject.Find("Ball"));
                FindObjectOfType<UIController>().ActivarLosePanel();
                
            }
            else
            {
                FindObjectOfType<Ball>().ResetBall();
            }
            FindObjectOfType<UIController>().UpdateUILives(playerLives);
        }
    }

    [SerializeField] bool gameStarted;
    public bool GameStarted
    { 
        get => gameStarted;
        set
        {
            gameStarted = value;
            gameTime = Time.time;
        }
       
    }

    [SerializeField] bool ballOnPlay;
    public bool BallOnPlay
    {
        get => ballOnPlay;
        set
        {
            ballOnPlay = value;
            if (ballOnPlay == true)
            { 
                Debug.Log("Lanzar la bola");
            
                FindObjectOfType<Ball>().LaunchBall();
            }

        }
    }
}
