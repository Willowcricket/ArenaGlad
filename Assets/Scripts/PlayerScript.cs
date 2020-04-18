using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 1.5f;
    private Animator anime;
    private SoundManager SoundManager;

    public GameObject SwordBlade;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anime = gameObject.GetComponent<Animator>();
        SoundManager = GameManager.instance.GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
        InputHandler();
    }

    void InputHandler()
    {
        //Movement on X-axis
        float xMovement = Input.GetAxis("Horizontal") * speed;
        rb2d.velocity = new Vector2(xMovement, rb2d.velocity.y);
        //Movement on Y-axis
        float yMovement = Input.GetAxis("Vertical") * speed;
        rb2d.velocity = new Vector2(rb2d.velocity.x, yMovement) * speed;

        //Setting Attack Animation to Play
        if (Input.GetMouseButtonDown(0))
        {
            anime.SetBool("AttackWOShield", true);
            SoundManager.PlaySword();
        }
        else
        {
            anime.SetBool("AttackWOShield", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameManager.instance.playerMedkits > 0)
            {
                GameManager.instance.playerMedkits--;
                GameManager.instance.playerHealth = GameManager.instance.playerHealth + 20;
            }
        }
    }

    void FollowMouse()
    {   //So that the Player looks towards the mouse
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}