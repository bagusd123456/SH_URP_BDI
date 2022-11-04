using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("Parameter")]
    public GameObject player;
    public float minDistance;
    public float moveSpeed;

    public bool follow;
    public float seenPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance > minDistance && follow)
        {
            Vector3 direction = player.transform.position - this.transform.position;
            gameObject.GetComponent<Rigidbody>().AddForce(direction * moveSpeed * Time.deltaTime, ForceMode.Acceleration);
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
