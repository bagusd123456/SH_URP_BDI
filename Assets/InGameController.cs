using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameController : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score;
    public GameObject targetGO;

    public Material targetMat;
    public Color startColor;
    public Color targetColor;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //targetMat = targetGO.GetComponent<MeshRenderer>().material;
        scoreText.text = "Score: " + score;
        targetGO.GetComponent<MeshRenderer>().material.color = Color.Lerp(startColor, targetColor, Mathf.Lerp(0,1,time));

    }

    public void AddScore()
    {
        score++;
    }

    public void ChangeBallColor()
    {
        time = 0;
        startColor = targetColor;
        targetColor = Random.ColorHSV();
        
    }

    public void ChangeColor()
    {
        //targetMat.color = Random.ColorHSV();
        targetMat.SetColor("_SkyTint", Random.ColorHSV());
    }

    public void Lerp()
    {

    }
}
