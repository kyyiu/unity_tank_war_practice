using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float moveSpeed = 3;
    private SpriteRenderer sr;
    // 子弹需要转的度数
    private Vector3 bulletEulerAngles;
    public GameObject bulletPrefab;
    public Sprite[] move;
    private float cd = 0.4f;
    private float cdTime;
    public GameObject explosion;

    float h = 0;
    float v = -1;
    private float changeDirectionTime = 4;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Ttk();
    }

    private void FixedUpdate()
    {
        UserControll();
    }

    public void Die()
    {
        PlayerManager.Instance.score++;
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void UserControll()
    {
        if (changeDirectionTime >= 4)
        {
            int num = Random.Range(0, 8);
            if (num > 5)
            {
                v = -1;
                h = 0;
            } else if(num == 0)
            {
                v = 1;
                h = 0;
            } else if (num > 0 && num <=2)
            {
                h = -1;
                v = 0;
            } else if(num > 2 && num <=4)
            {
                h = 1;
                v = 0;
            }
            changeDirectionTime = 0;
        } else
        {
            changeDirectionTime += Time.deltaTime;
        }

        if (h != 0)
        {
            sr.sprite = move[h < 0 ? 3 : 1];
            transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
            bulletEulerAngles = new Vector3(0, 0, h > 0 ? -90 : 90);
            return;
        }
        if (v != 0)
        {
            sr.sprite = move[v < 0 ? 2 : 0];
            transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
            bulletEulerAngles = new Vector3(0, 0, v > 0 ? 0 : -180);
        }

    }

    private void Ttk()
    {
        if (cdTime < cd)
        {
            cdTime += Time.deltaTime;
            return;
        }
        Debug.Log("EEE");
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles));
        cdTime = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ETank")
        {
            changeDirectionTime = 4;
        }
    }
}
