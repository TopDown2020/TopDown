using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Switchj : MonoBehaviour
{
    public event Action<int> OnPress = delegate {};
    [SerializeField]
    private int _id;

    public Doorj2 doorj2;

    private Animator _animator;
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;

    public void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        doorj2.OnFail += Reset;
    }

    private void OnDisable()
    {
        doorj2.OnFail -= Reset;
    }

    private void Reset()
    {
        _animator.SetBool("Active", false);
        _boxCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerShadow"))
        {
            _audioSource.clip = AudioList.Instance.button;
            _audioSource.Play();
            _animator.SetBool("Active", true);
            _boxCollider.enabled = false;
            OnPress.Invoke(_id);
        }
    }
}