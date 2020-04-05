using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioList : MonoBehaviour
{
    public AudioClip dash;
    public AudioClip swordSwing;
    public AudioClip playerAttack01;
    public AudioClip playerAttack02;
    public AudioClip step01;
    public AudioClip step02;
    public AudioClip gethit;
    public AudioClip enemystep;
    public AudioClip goblinhit;
    public AudioClip goblindeath;
    public AudioClip goblindeath02;
    public AudioClip slimemoving;
    public AudioClip button;
    public AudioClip opendoor_chest;
    public AudioClip puzzleerror;
    public AudioClip menuchange;
    public AudioClip mainmusic;

    public AudioClip walk;
    public AudioClip attack;
    public AudioClip die;

    
    public static AudioList Instance;
    private void Awake()
    {
        Instance = this; 
    }
}
