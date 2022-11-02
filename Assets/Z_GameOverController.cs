using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Z_GameOverController : MonoBehaviour
{
    public TMP_Text gameOverText;
    public float multiplier = 2f;
    public Color targetColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameOverText.color = Color.Lerp(Color.white,targetColor,Mathf.PingPong(Time.time * multiplier,1));
        
        gameOverText.alpha = Mathf.Lerp(0, 1, Mathf.PingPong(Time.unscaledTime * multiplier, 1));
    }
}
