using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMan : MonoBehaviour
{
    public BallController theBall;
    public bool gameActive;
    public Text livesText;
    public int lives;

    public Text scoreText;

    public int currentScore;

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives Left : " + lives;
        scoreText.text = " SCORE : " + currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !gameActive)
        {
          theBall.ActivateBall();
          gameActive = true;
        }
    }

    public void RespawnBall()
    {
        gameActive = false;
        lives -= 1;

        if(lives <= 0)
        {
            theBall.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            livesText.text = "  YOU LOST YOUR LIVES ";
        }
        livesText.text = "Lives Left : " + lives;
    }

    public void AddScore(int scoreToAdd)
    {
      currentScore += scoreToAdd;
      scoreText.text = " SCORE : " + currentScore;
    }
}
