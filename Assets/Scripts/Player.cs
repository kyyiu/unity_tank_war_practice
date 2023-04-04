using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
    private bool isDefend = true;
    private float defendTime = 1.5f;
    public GameObject defendPrefab;
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
        defend();
        Ttk();
    }

    private void FixedUpdate()
    {
        UserControll();
    }

    private void defend()
    {
        if (isDefend)
        {
            defendTime -= Time.deltaTime;
            defendPrefab.SetActive(true);
            if (defendTime <= 0)
            {
                isDefend = false;
                defendPrefab.SetActive(false);
            }
        }
    }

    private void Die()
    {
        if (isDefend)
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void UserControll()
    {
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (h!=0)
        {
            sr.sprite = move[h < 0 ? 3 : 1];
            transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
            bulletEulerAngles = new Vector3(0, 0, h > 0 ? -90 : 90);
            return;
        }
        if (v!=0)
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 子弹产生的角度= 当前角色的角度+ 子弹应该旋转的角度
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles ));
            cdTime = 0;
        }
    }
}
