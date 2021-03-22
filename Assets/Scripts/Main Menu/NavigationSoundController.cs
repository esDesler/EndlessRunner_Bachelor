using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationSoundController : MonoBehaviour
{
    private AudioSource forwardSound;
    private AudioSource backwardSound;
    private AudioSource selectSound;

    // Start is called before the first frame update
    void Start()
    {
        forwardSound = GameObject.Find("Menu_Click").GetComponent<AudioSource>();
        backwardSound = GameObject.Find("Menu_ClickBack").GetComponent<AudioSource>();
    }

    public void PlayForwardSound()
    {
        forwardSound.Play();
    }

    public void PlayBackwardSound()
    {

    }
}
