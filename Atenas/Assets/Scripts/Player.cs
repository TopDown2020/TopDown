using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private MoveBehaviour _moveBehaviour;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private AttackBehaviour _attackBehaviour;
    private SoundPlayer _soundPlayer;
    private TrailBehaviour _trailBehaviour;

    private Vector2 _dashDir;
    private Vector2 _axis;
    private float _coldown = 1.5f;
    private float _nextDash;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _attackBehaviour = GetComponent<AttackBehaviour>();
        _trailBehaviour = GetComponent<TrailBehaviour>();
    }

    void Update()
    {
        _axis = new Vector2 (Input.GetAxis("HorizontalStick"), Input.GetAxis("VerticalStick"));

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && Time.time > _nextDash && _animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            _nextDash = Time.time + _coldown;
            _dashDir = new Vector2 (_animator.GetFloat("X"), _animator.GetFloat("Y"));
            _animator.SetTrigger("Dash");
            _trailBehaviour.StartCoroutine("DashTrail");
            //_soundPlayer.DashingSound();
            GetComponent<AudioSource>().PlayOneShot(AudioList.Instance.dash, 0.6f);
        }

        else if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("1Attack"))
                _animator.SetTrigger("Attack2");
            else
                _animator.SetTrigger("Attack1");
        }

        else if (_axis.x != 0f || _axis.y != 0f)
            _animator.SetBool("Moving", true);

        else
            _animator.SetBool("Moving", false);
    }

    void FixedUpdate()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Dash"))
        {
            _moveBehaviour.Move(_dashDir.normalized);
        }
        
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Run") && (_axis.x != 0f || _axis.y != 0f))
        {
            _animator.SetFloat("X", _axis.x);
            _animator.SetFloat("Y", _axis.y);

            if ((_axis.x <= 0) && ((_axis.y <= 0 && (-_axis.x > -_axis.y)) || (_axis.y >= 0 && (-_axis.x > _axis.y))))
            {
                _spriteRenderer.flipX = true;
                _attackBehaviour.FlipAttack(true);
            }

            else
            {
                _spriteRenderer.flipX = false;
                _attackBehaviour.FlipAttack(false);
            }
            
            _moveBehaviour.Move(_axis);
        }
    }
}