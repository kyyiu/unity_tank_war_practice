using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    public int life = 3;
    public int score = 0;
    public bool isDead;
    public GameObject born;

    public bool isDefeat;

    public Text scoreText;
    public Text lifeText;

    public GameObject isDefeatUI;

    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void ReBorn()
    {
        if (life <= 0)
        {
            isDefeat = true;
            Invoke("ReturnTheme", 4);
            return;
        }
        life--;
        Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity)
            .GetComponent<Born>().createPlayer = true;
        isDead = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefeat)
        {
            isDefeatUI.SetActive(true);
            return;
        }
        if (isDead)
        {
            ReBorn();
        }
        scoreText.text = score.ToString();
        lifeText.text = life.ToString();
    }

    private void ReturnTheme()
    {
        SceneManager.LoadScene(0);
    }
}
