using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByBulletSound : MonoBehaviour
{
    //basically if you have this script, you make a sound when you get hit by a bullet
    [SerializeField] private AudioSource hitSound;
    
    public void PlayHitSound()
    {
        hitSound.Play();
    }
}
