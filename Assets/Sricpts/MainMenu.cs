using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public HighScore highScore;
    public TextMeshProUGUI highScoreValue;
    public GameObject highScoreMenu;



   public void Play()
    {
        //Debug.Log("Button Clicked!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void OpenHighScore()
    {
        highScoreMenu.SetActive(true);
        highScoreValue.text = highScore.highScore.ToString();
    }


    public void CloseHighScore()
    {
        highScoreMenu.SetActive(false);
    }

    public void ResetHighScore()
    {
        highScore.highScore = 0;
    }
}
