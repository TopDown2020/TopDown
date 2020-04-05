using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Doorj2 : MonoBehaviour
{
    public event Action OnFail = delegate {};
    public Switchj[] switchj = new Switchj[3];
    private Animator _animator;
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;

    [SerializeField]
    private int[] _doorCode = new int[3];
    private int[] _enterCode = new int[3];

    public void Awake()
    {
        for (int num = 0 ; num < 3 ; num++)
            _enterCode[num] = 0;

        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        switchj[0].OnPress += Unlock;
        switchj[1].OnPress += Unlock;
        switchj[2].OnPress += Unlock;
    }

    private void OnDisable()
    {
        switchj[0].OnPress -= Unlock;
        switchj[1].OnPress -= Unlock;
        switchj[2].OnPress -= Unlock;
    }

    private void Unlock(int button)
    {
        if (_enterCode[0] == 0)
            _enterCode[0] = button;
        else
            if (_enterCode[1] == 0)
                _enterCode[1] = button;
            else
            {
                _enterCode[2] = button;
                
                if (_doorCode[0] == _enterCode[0] && _doorCode[1] == _enterCode[1] && _doorCode[2] == _enterCode[2])
                {
                    _audioSource.clip = AudioList.Instance.opendoor_chest;
                    _audioSource.Play();
                    _animator.SetBool("Open", true);
                    _boxCollider.enabled = false;
                }
                else
                {
                    for (int num = 0 ; num < 3 ; num++)
                        _enterCode[num] = 0;
                        
                    
                    StartCoroutine(WaitForReload(2.0f));
                }
            }
    }

     IEnumerator WaitForReload(float time)
    {
        yield return new WaitForSeconds(time);
        _audioSource.clip = AudioList.Instance.puzzleerror;
        _audioSource.Play();
        OnFail.Invoke();
    }
}