using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public List<NPC> gameObjects;
    public GameObject enemyGO;
    public float moveSpeed;
    public enum moveType{ cube, sphere}
    public moveType _moveType;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objectList = GameObject.FindGameObjectsWithTag("NPC");
        foreach (var item in objectList)
        {
            gameObjects.Add(item.GetComponent<NPC>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            Vector3 direction = gameObjects[i].transform.position - transform.position;
            gameObjects[i].seenPlayer = Vector3.Dot(transform.forward, direction);

            if (gameObjects[i].seenPlayer >= 6)
            {
                gameObjects[i].follow = false;
            }
            else if (gameObjects[i].seenPlayer <= -6)
            {
                gameObjects[i].follow = true;
            }
        }
        

        if (_moveType == moveType.cube)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            transform.position += new Vector3(horizontal,0,vertical) * moveSpeed * Time.deltaTime;
        }

        else if(_moveType == moveType.sphere)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(horizontal, 0, vertical) * moveSpeed, ForceMode.Acceleration);
        }
        
        
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * 15f,Color.red);
    }
}
