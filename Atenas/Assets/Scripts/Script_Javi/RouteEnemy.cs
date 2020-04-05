using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RouteEnemy : MonoBehaviour
{
    public event Action OnGetDamage = delegate {};
    public GameObject player;
    public RouteEnemy[] routenemy;
    private MoveBehaviour _moveBehaviour;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private RoutineBehaviour _routineBehaviour;
    private HealthBehaviour _healthBehaviour;

    private bool _patrol = true;
    private float _prevPos;

    public void Awake()
    {
        _routineBehaviour=GetComponent<RoutineBehaviour>();
        if(_routineBehaviour == null)
            _patrol=false;
        _moveBehaviour=GetComponent<MoveBehaviour>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void Start()
    {
        player = GameObject.Find("Player");
    }

    public void FixedUpdate()
    {
        if (_patrol)
        {   
            _animator.SetBool("Moving", true);
            if (_prevPos > transform.position.x)
                _spriteRenderer.flipX = true;
            else if (_prevPos < transform.position.x)
                _spriteRenderer.flipX = false;

            _routineBehaviour.Route(new Vector3(transform.position.x,
                                                transform.position.y, 0));
            _prevPos = transform.position.x;
        }

        else if (player != null)
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Hit") && !_animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            {    
                _animator.SetBool("Moving", true);
                if (player.transform.position.x - transform.position.x < 0)
                    _spriteRenderer.flipX = true;
                else if (_prevPos < transform.position.x)
                    _spriteRenderer.flipX = false;

                _moveBehaviour.Move(new Vector2(player.transform.position.x - transform.position.x,
                                                player.transform.position.y - transform.position.y).normalized);
            }
        }
        
        else
            _animator.SetBool("Moving", false);
    }

    public void OnEnable()
    {
        foreach (RouteEnemy mate in routenemy)
        {
            mate.OnGetDamage += AttackPlayer;
        }
    }

        public void OnDisable()
    {
        foreach (RouteEnemy mate in routenemy)
        {
            mate.OnGetDamage -= AttackPlayer;
        }
    }

    public void AttackPlayer()
    {
        _patrol = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("attack"))
        {
            OnGetDamage.Invoke();
        }
    }
}
