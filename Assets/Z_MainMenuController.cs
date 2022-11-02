using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Z_MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;

    public int highScore;
    public TMP_Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = highScore.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
