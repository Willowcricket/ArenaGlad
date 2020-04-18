using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource AudioS;

    public AudioClip Sword;
    public AudioClip Grunt;

    // Start is called before the first frame update
    void Start()
    {
        AudioS = gameObject.GetComponent<AudioSource>();
    }

    public void PlaySword()
    {
        AudioS.clip = Sword;
        AudioS.Play();
    }

    public void PlayGrunt()
    {
        AudioS.clip = Grunt;
        AudioS.Play();
    }
}