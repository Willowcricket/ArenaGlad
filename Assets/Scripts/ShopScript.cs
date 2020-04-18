using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public Canvas ShopCanvas;
    public Transform ShopT;
    public GameObject EButtonPreFab;
    public GameObject EPrompt;

    // Start is called before the first frame update
    void Start()
    {
        ShopCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(EButtonPreFab);
        }
        if (collision.gameObject.tag == "EButtonPrompt")
        {
            EPrompt = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(EPrompt);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                EnterShop();
            }
        }
        if (collision.gameObject.tag == "EButtonPrompt")
        {
            EPrompt = collision.gameObject;
        }
    }

    public void BuyMedkit()
    {
        if (GameManager.instance.playerCoin >= 45)
        {
            GameManager.instance.playerCoin = GameManager.instance.playerCoin - 45;
            GameManager.instance.playerMedkits++;
        }
    }

    public void EnterShop()
    {
        ShopCanvas.enabled = true;
        GameManager.instance.Player.GetComponent<PlayerScript>().enabled = false;
    }

    public void ExitShop()
    {
        ShopCanvas.enabled = false;
        GameManager.instance.Player.GetComponent<PlayerScript>().enabled = true;
    }
}
