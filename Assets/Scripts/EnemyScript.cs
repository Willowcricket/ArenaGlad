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


    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "StopBox")
        {

        }
    }

    public void rotateTowards(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        float zAngle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 0);
        transform.rotation = Quaternion.Euler(0, 0, zAngle - 90);
    }
}
