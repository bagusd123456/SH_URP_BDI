using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject[] zombiePrefab;
    public TMP_Text textWord;
    public Transform[] spawnPoint;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;

    float spawnTimeout = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimeout > 0)
            spawnTimeout -= Time.deltaTime;
        else
        {
            spawnTimeout = Random.Range(minSpawnTime, maxSpawnTime);
            var clone = Instantiate(zombiePrefab[Random.Range(0, 2)], spawnPoint[Random.Range(0, spawnPoint.Length)]);
            
            if(clone.GetComponent<ZombieData>()._zombieType == ZombieData.zombieType.TYPING)
            {
                int index = Random.Range(0, GameManager.Instance.words.Count);
                
                GameManager.Instance.words[index].onTyped = new UnityEvent();
                GameManager.Instance.words[index].onTyped.AddListener(clone.GetComponent<ZombieMovement>().DestroyCurrent);


                var text = Instantiate(textWord, clone.transform);
                text.text = GameManager.Instance.words[index].text;
            }


        }
    }
}
