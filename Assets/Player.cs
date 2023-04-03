using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        userControll();
    }

    private void userControll()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * v * moveSpeed * Time.deltaTime, Space.World);
    }
}
