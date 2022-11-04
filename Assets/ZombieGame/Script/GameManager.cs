using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;
using System.IO;
using Doozy;
using Doozy.Runtime.UIManager.Containers;

public class GameManager : MonoBehaviour
{
    public enum gameState { IDLE, GAMEPLAY, BUSY, GAMESTOP, WIN, LOSE}
    public gameState _GameState = gameState.GAMEPLAY;
    public int lives = 3;
    public int score;

    public GameObject losePanel;
    public int highScore;

    [Space]
    public List<Word> words;
    public TMP_Text display;
    public List<ZombieData> zombieData;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < words.Count; i++)
        {
            if(words.Count < 40)
            {
                string[] text = System.IO.File.ReadAllLines("D:\\SH_BDI\\SH_URP_BDI\\Assets\\ZombieGame\\TextList.txt");
                words.Add(new Word(text[i].ToString()));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHighScore();
        
        CheckState();
        
    }

    public void UpdateHighScore()
    {
        if (score > highScore)
            PlayerPrefs.SetInt("HighScore", score);
    }

    public void CheckState()
    {
        if (_GameState == gameState.IDLE)
            Time.timeScale = 0f;

        else if (_GameState == gameState.GAMEPLAY)
        {
            Time.timeScale = 1f;
            if (lives <= 0)
                _GameState = gameState.LOSE;
            else if (lives > 0)
                _GameState = gameState.GAMEPLAY;
        }

        else if (_GameState == gameState.LOSE)
        {
            losePanel.SetActive(true);
            losePanel.GetComponent<UIContainer>().Show();
            Time.timeScale = 0f;
            if (Input.anyKey)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        
    }
}
