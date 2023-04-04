using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10;
    public byte playerFlag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Wall"+ collision.tag);
        switch (collision.tag)
        {
            case "Tank":
                if (playerFlag != 1)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Home":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Wall":
               
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "MWall":
                Destroy(gameObject);
                break;
            case "ETank":
                if (playerFlag == 1)
                {
                    collision.SendMessage("Die");
                }
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}