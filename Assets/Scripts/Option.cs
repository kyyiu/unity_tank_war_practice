using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Option : MonoBehaviour
{
    private int choice = 1;
    public Transform p1;
    public Transform p2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("WW");
            choice = 1;
            transform.position = p1.position;
        } else if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("SS");
            choice = 2;
            transform.position = p2.position;
        }
        if (choice == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
}
