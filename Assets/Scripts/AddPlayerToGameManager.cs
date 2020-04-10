using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerToGameManager : MonoBehaviour
{
    // This goes on a script on the player prefab
    void Start()
    {
        // We only want one player game object to exist at any given time.
        if (GameManager.instance.Player != null)
        {
            Debug.LogWarning("Attempted to instantiate a second player prefab");
            Destroy(this.gameObject);
        }
        else
        {
            // Add our new player instance to the GameManager
            GameManager.instance.Player = this.gameObject;
        }
    }
}
