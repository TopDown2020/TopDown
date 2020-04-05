using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OpenOnKill : MonoBehaviour
{
    public int encount = 3;
    public void lowcount()
    {
        encount--;
        if (encount <= 0)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audio.clip, 1f);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
