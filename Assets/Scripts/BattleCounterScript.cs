using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCounterScript : MonoBehaviour
{
    public int Enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemies = GameManager.instance.Enemies;
        if (Enemies == 0)
        {
            GameManager.instance.LoadLevel(1);
        }
    }
}
