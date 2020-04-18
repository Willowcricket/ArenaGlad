using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Player;
    public int playerHealth = 100;
    public int playerCoin = 0;
    public int playerMedkits = 0;
    public int Enemies = 0;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogError("I tried to create a second game manager");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (playerHealth > 100)
        {
            playerHealth--;
        }
        if (playerHealth <= 0)
        {
            LoadLevel(6);
        }
    }

    public void LoadLevel(int indexToLoad)
    {
        SceneManager.LoadScene(indexToLoad);
    }
}
