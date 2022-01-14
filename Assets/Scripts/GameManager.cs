using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    private int lives = 3;

    public int maxLives = 3;
    public GameObject gameOverCanvas;
    public TMP_Text livesText;

    // Singleton method
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        RestartGame();
    }

    public void RestartGame()
    {
        lives = maxLives;
        gameOverCanvas.SetActive(false);
        livesText.text = "LIVES : " + lives;
    }

    public void LoseLife()
    {
        lives--;

        // update the textbox
        livesText.text = "LIVES : " + lives;

        // if the lives are less than 0, then Game Over!!!
        if(lives < 0)
        {
            gameOverCanvas.SetActive(true);
            livesText.text = "Gone!";
        }
    }
    
}
