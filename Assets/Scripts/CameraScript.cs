﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            Player = GameManager.instance.Player;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        this.gameObject.transform.position = new UnityEngine.Vector3(Player.transform.position.x, Player.transform.position.y, -10);
    }
}
