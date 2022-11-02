using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZombieMovement : MonoBehaviour,IPointerClickHandler
{
    public GameObject target;
    public float moveSpeed;

    Rigidbody2D rb;
    private void Awake()
    {
        if(target == null)
            target = GameObject.Find("Target");
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }

    public void DestroyCurrent()
    {
        GameManager.Instance.score++;
        Destroy(gameObject);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if(gameObject.GetComponent<ZombieData>()._zombieType == ZombieData.zombieType.BASIC)
        {
            GameManager.Instance.score++;
            Destroy(gameObject);
        }

        /*if(transform.position.x < 250)
            transform.position += new Vector3(50, 0, 0);
        else
            transform.position += new Vector3(-50, 0, 0);*/

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("EndCollider"))
        {
            GameManager.Instance.lives--;
            Destroy(gameObject);
        }
    }
}
