using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioooo : MonoBehaviour
{
    public AudioClip Act1;
    public AudioClip Act2;
    public AudioClip Act3;
    public AudioClip Act4;

    public static Audioooo Instance;

    private void Awake()
    {
        Instance = this;
    }
}
