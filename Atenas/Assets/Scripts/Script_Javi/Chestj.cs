using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Chestj : MonoBehaviour
{
    public event Action OnOpen = delegate {};
    private Animator _animator;
    private AudioSource _audioSource;
    private bool _open = false;


    public void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerShadow") && Input.GetKeyDown(KeyCode.Joystick1Button1) && !_open)
        {
            _audioSource.clip = AudioList.Instance.opendoor_chest;
            _audioSource.Play();
            OnOpen.Invoke();
            _animator.SetBool("Open", true);
            _open = true;
        }
    }
}
