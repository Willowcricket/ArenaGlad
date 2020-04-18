using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManScript : MonoBehaviour
{
    public Canvas BattleCanvas;
    public Transform ShopT;
    public GameObject EButtonPreFab;
    public GameObject EPrompt;

    // Start is called before the first frame update
    void Start()
    {
        BattleCanvas.enabled = false;
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

    public void EnterShop()
    {
        BattleCanvas.enabled = true;
        GameManager.instance.Player.GetComponent<PlayerScript>().enabled = false;
    }

    public void ExitShop()
    {
        BattleCanvas.enabled = false;
        GameManager.instance.Player.GetComponent<PlayerScript>().enabled = true;
    }

    public void BuyFreedom(int Free)
    {
        if (GameManager.instance.playerCoin >= 200)
        {
            BattleFunc(Free);
        }
    }

    public void BattleFunc(int Battle)
    {
        GameManager.instance.LoadLevel(Battle);
    }
}
