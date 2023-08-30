using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSoundPlayer : MonoBehaviour
{
    public AudioSource jumpSound;
    public AudioSource impactSound;
    public AudioSource coinSound;

    public void playJump()
    {
        jumpSound.Play();
    }

    public void playCoin()
    {
        coinSound.Play();
    }

    public void playImpact() 
    {
        impactSound.Play();
    }
}
