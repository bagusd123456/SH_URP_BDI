using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Z_InGameController : MonoBehaviour
{
    public GameObject pausePanel;

    public TMP_Text scoreText;
    public TMP_Text livesText;

    public TMP_Text gamePausedText;
    public float multiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.score;
        livesText.text = "Lives: " + GameManager.Instance.lives;

        if (GameManager.Instance._GameState == GameManager.gameState.IDLE)
        {
            gamePausedText.alpha = Mathf.Lerp(0, 1, Mathf.PingPong(Time.unscaledTime * multiplier, 1));
            if (Input.anyKey)
            {
                pausePanel.SetActive(false);
                GameManager.Instance._GameState = GameManager.gameState.GAMEPLAY;
            }
        }
    }

    public void PauseGame()
    {
        if (GameManager.Instance._GameState == GameManager.gameState.GAMEPLAY)
        {
            pausePanel.SetActive(true);
            GameManager.Instance._GameState = GameManager.gameState.IDLE;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
