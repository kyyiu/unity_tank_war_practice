using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject explosionPrefab;
    public Sprite broken;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        PlayerManager.Instance.isDefeat = true;
        sr.sprite = broken;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }
}
