using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 3;
    private SpriteRenderer sr;
    public Sprite[] move;
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
        
    }

    private void FixedUpdate()
    {
        UserControll();
    }

    private void UserControll()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (h!=0)
        {
            sr.sprite = move[h < 0 ? 3 : 1];
            transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
            return;
        }
        if (v!=0)
        {
            sr.sprite = move[v < 0 ? 2 : 0];
            transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
        }
        
    }


}
