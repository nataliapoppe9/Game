using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject[] livesImg;
    [SerializeField] Text gameTimeText;

    public void ActivarLosePanel()
    {
        losePanel.SetActive(true);
    }

    public void ActivarWinPanel(float gameTime)
    {
        winPanel.SetActive(true);
        gameTimeText.text = "Game Time:" + " " + Mathf.Floor(gameTime) + "s";
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToMainMenu()
    {
      //  ChangeScene.cs.LoadMyScene("SampleScene");
        SceneManager.LoadScene("SampleScene");
        ChangeScene.cs.loaded = true;
        
    }

    public void UpdateUILives(byte currentLives)
    {
        for (int i = 0; i < livesImg.Length; i++)
        {
            if(i >= currentLives)
            {
                livesImg[i].SetActive(false);
            }
        }
    }
}
