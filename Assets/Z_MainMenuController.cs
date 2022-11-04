using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Doozy;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using Doozy.Runtime.UIManager.Components;

public class Z_MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;

    public int highScore;
    public TMP_Text highScoreText;
    public bool loaded;
    [Space]

    [Header("Sound Setting")]
    public UIToggle masterVolume;
    public UISlider masterSlider;
    public UIToggle BGMVolume;
    public UISlider bgmSlidier;
    public UIToggle SFXVolume;
    public UISlider SFXSlider;

    private void Awake()
    {
        masterSlider.value = SoundManager.Instance._masterVolume;
        bgmSlidier.value = SoundManager.Instance._BGMVolume;
        SFXSlider.value = SoundManager.Instance._SFXVolume;

        masterVolume.IsOn = !AudioListener.pause;
        BGMVolume.isOn = SoundManager.Instance.BGMSource.enabled;
        SFXVolume.isOn = SoundManager.Instance.SFXSource.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = highScore.ToString();
        UpdateVolume();
        
    }

    public void UpdateVolume()
    {
        SoundManager.Instance._masterVolume = masterSlider.value;
        SoundManager.Instance._BGMVolume = bgmSlidier.value;
        SoundManager.Instance._SFXVolume = SFXSlider.value;

        AudioListener.pause = !masterVolume.isOn;
        SoundManager.Instance.BGMSource.enabled = BGMVolume.isOn;
        SoundManager.Instance.SFXSource.enabled = SFXVolume.isOn;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
