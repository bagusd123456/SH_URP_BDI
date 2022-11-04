using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WordManager : MonoBehaviour {

	public List<Word> words;
	public List<ZombieData> zombieData;

	public WordSpawner wordSpawner;

	private bool hasActiveWord;
	private Word activeWord;

    public static WordManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

	private void Start()
	{
        AddWord();
        for (int i = 0; i < words.Count; i++)
        {
            if (words.Count < 40)
            {
                AddWord();
            }
        }
    }

	public void AddWord()
	{
        string[] text = System.IO.File.ReadAllLines("D:\\SH_BDI\\SH_URP_BDI\\Assets\\ZombieGame\\TextList.txt");
        Word word = new Word(text[Random.Range(0,text.Length)]);
		//Debug.Log(word.word);

		words.Add(word);
	}

	public void TypeLetter (char letter)
	{
		if (hasActiveWord)
		{
			if (activeWord.GetNextLetter() == letter)
			{
				activeWord.TypeLetter();
			}
		} 
		
		else
		{
			foreach(Word word in words)
			{
				if (word.GetNextLetter() == letter)
				{
					activeWord = word;
					hasActiveWord = true;
					word.TypeLetter();
					break;
				}
			}
		}

		if (hasActiveWord && activeWord.WordTyped())
		{
			hasActiveWord = false;
            activeWord.eventTrigger.Invoke();
			words.Remove(activeWord);
		}
	}

}

[System.Serializable]
public class Word
{
    public string word;
    private int typeIndex;
    public UnityEvent eventTrigger;

    //TMP_Text display;

    public Word(string _word)
    {
        word = _word;
        typeIndex = 0;

        //display = _display;
        //display.text = word;
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
        //display.text.TrimStart();
    }

    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if (wordTyped)
        {
            //display.text.Trim();
        }
        return wordTyped;
    }
}
