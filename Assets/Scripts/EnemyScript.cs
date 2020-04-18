using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform tf;
    public float movementSpeed = 1.25f;
    public float rotatinSpeed = 60;
    public Transform target;
    private Animator anime;
    public bool attackMode = false;


    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        anime = gameObject.GetComponent<Animator>();
        GameManager.instance.Enemies++;
    }

    // Update is called once per frame
    void Update()
    {
        tf.position += tf.up * movementSpeed * Time.deltaTime;
        if (target == null)
        {
            if (GameManager.instance.Player)
            {
                target = GameManager.instance.Player.transform;
            }
        }
        else
        {
            rotateTowards(target);
        }

        if (attackMode == true)
        {
            movementSpeed = 0.0f;
        }
        else
        {
            movementSpeed = 1.25f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerSwordBlade")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "StopBox")
        {
            attackMode = false;
            AttackingChecks();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "StopBox")
        {
            attackMode = true;
            AttackingChecks();
        }
    }

    private void AttackingChecks()
    {
        if (attackMode == true)
        {
            anime.SetBool("EnemyAttackT", true);
        }
        else
        {
            anime.SetBool("EnemyAttackT", false);
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.playerCoin = GameManager.instance.playerCoin + 5;
        GameManager.instance.Enemies--;
    }

    public void rotateTowards(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        float zAngle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 0);
        transform.rotation = Quaternion.Euler(0, 0, zAngle - 90);
    }
}
