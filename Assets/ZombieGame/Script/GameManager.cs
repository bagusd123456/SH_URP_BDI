using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;
using System.IO;

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
    List<GameObject> zombieList;
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
                words.Add(new Word(text[i]));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHighScore();
        TypingMechanic();
        
        CheckState();
        if(_GameState == gameState.LOSE)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0f;
            if (Input.anyKey)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        else if(_GameState == gameState.IDLE)
        {
            Time.timeScale = 0f;
        }

        else if(_GameState == gameState.GAMEPLAY)
        {
            Time.timeScale = 1f;
        }
    }

    public void UpdateHighScore()
    {
        if (score > highScore)
            PlayerPrefs.SetInt("HighScore", score);
    }

    public void CheckState()
    {
        if(_GameState != gameState.IDLE)
        {
            if (lives <= 0 && _GameState == gameState.GAMEPLAY)
                _GameState = gameState.LOSE;
            else if (lives > 0)
                _GameState = gameState.GAMEPLAY;
        }
    }

    public void TypingMechanic()
    {
        string input = Input.inputString;
        if (input.Equals(""))
            return;

        char c = input[0];
        string typing = "";
        for (int i = 0; i < words.Count; i++)
        {
            Word w = words[i];
            if (w.continueText(c))
            {
                string typed = w.getTyped();
                typing += typed + "\n";
                if (typed.Equals(w.text))
                {
                    Debug.Log("Typed: " + w.text);
                    words.Remove(w);
                    break;
                }
            }
        }
        display.text = typing;
    }
}

[System.Serializable]
public class Word
{
    public string text;
    public UnityEvent onTyped;
    string hasTyped = "";
    int curChar = 0;

    public Word(string t)
    {
        text = t;
        hasTyped = "";
        curChar = 0;
    }

    public bool continueText(char c)
    {
        if (c.Equals(text[curChar]))
        {
            curChar++;
            hasTyped = text.Substring(0, curChar);

            if(curChar >= text.Length)
            {
                onTyped.Invoke();
                curChar = 0;
            }
            return true;
        }
        else
        {
            curChar = 0;
            hasTyped = "";
            return false;
        }
    }

    public string getTyped()
    {
        return hasTyped;
    }
}
