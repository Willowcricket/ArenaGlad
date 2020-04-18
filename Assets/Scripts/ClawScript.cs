using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawScript : MonoBehaviour
{
    public SoundManager SoundManager;

    private void Start()
    {
        SoundManager = GameManager.instance.GetComponent<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player was hit");
            SoundManager.PlayGrunt();
            GameManager.instance.playerHealth--;
        }
    }
}
