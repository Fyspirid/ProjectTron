using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource sounds;
    [SerializeField] private AudioClip clicksSound;
    public void ClickSound()
    {
        sounds.PlayOneShot(clicksSound);
    }
}
