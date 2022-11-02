using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateImage : MonoBehaviour
{
    public RectTransform[] healthGO;
    public float multiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.lives == 3)
            PlayAnimation(healthGO[2]);

        else if (GameManager.Instance.lives == 2)
        {
            healthGO[2].gameObject.SetActive(false);
            multiplier = 6f;
            PlayAnimation(healthGO[1]);
        }
            
        else if (GameManager.Instance.lives == 1)
        {
            healthGO[1].gameObject.SetActive(false);
            multiplier = 9f;
            PlayAnimation(healthGO[0]);
        }
            
        else if(GameManager.Instance.lives == 0)
        {
            healthGO[0].gameObject.SetActive(false);
        }
    }

    public void PlayAnimation(RectTransform heart)
    {
        float value = Mathf.Lerp(40f, 50f, Mathf.PingPong(Time.time * multiplier, 1));
        //healthGO.localScale = new Vector3(value, value);
        heart.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value);
        heart.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value);
    }
}
