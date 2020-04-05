using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemy_6 : MonoBehaviour
{
    public UnityEvent OpenToKill;

    [SerializeField]
    private AudioSource _audio;

    private AttackBehaviour _attackBehaviour;
    private MoveBehaviour _moveBehaviour;
    private HealthBehaviour _healthBehaviour;

    [SerializeField]
    private Transform _player;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private float _xdist;
    private float _ydist;

    private float _xdir;
    private float _ydir;

    private float _atkCd = 2f;
    private float _nextAtk = 0;


    public void Awake()
    {
        _audio = GetComponent<AudioSource>();

        _moveBehaviour = GetComponent<MoveBehaviour>();
        _healthBehaviour = GetComponent<HealthBehaviour>();
        _attackBehaviour = GetComponent<AttackBehaviour>();

        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        //ATTACK ANIMATION AND ENABLE ATTACK HITBOX DEPENDING ON DIRECTION
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (_spriteRenderer.flipX == false)
                _attackBehaviour.FlipAttack(false);
            else
                _attackBehaviour.FlipAttack(true);
            _attackBehaviour.Attack(1);
        }
        else
        {    
            _attackBehaviour.FlipAttack(true);
            _attackBehaviour.Attack(0);
            _attackBehaviour.FlipAttack(false);
            _attackBehaviour.Attack(0);
        }
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < 4)
        {
            //CALCUATE DISTANCE BETWEEN THE PLAYER AND THIS OBJECT
            _xdist = _player.transform.position.x - transform.position.x;
            _ydist = _player.transform.position.y - transform.position.y;

            //FLIP SPRITE
            if (_xdist > 0)
                _spriteRenderer.flipX = false;
            else if (_xdir < 0)
                _spriteRenderer.flipX = true;

            //DECIDE X DIRECTION BASED ON PLAYER'S POSITON
            if (_xdist >= -0.3f && _xdist <= 0.3f)
                _xdir = Mathf.Sign(_player.transform.position.x + 0.30f * -Mathf.Sign(_xdist) - transform.position.x);
            else if (_xdist >= -0.31f && _xdist <= 0.31f)
                _xdir = 0;
            else
                _xdir = Mathf.Sign(_player.transform.position.x + 0.30f * Mathf.Sign(_xdist) - transform.position.x);

            //DECIDE Y DIRECTION BASED ON PLAYER'S POSITON
            if (_ydist > -0.30f && _ydist < 0.15f)
                _ydir = 0;
            else
                _ydir = Mathf.Sign(_player.transform.position.y + 0.15f - transform.position.y);

            //ATTACK
            if (Mathf.Abs(_xdist) <= 0.35 && Mathf.Abs(_ydist) <= 0.35 && Time.time > _nextAtk)
            {
                _nextAtk= Time.time + _atkCd;
                _animator.SetTrigger("Attack");
                _audio.PlayOneShot(AudioList.Instance.attack, 0.6f);
            }
                

            //DECIDE IF GET HITBOX AND MOVE OR NOT (IF GETS HIT)
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
                GetComponent<Collider2D>().enabled = false;
            else
            {
                GetComponent<Collider2D>().enabled = true;
                if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    _audio.Play();
                    _moveBehaviour.Move(new Vector2(_xdir, _ydir));
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //DIE OR LOWER HEALTH
        if (col.gameObject.CompareTag("attack"))
        {
            OpenToKill.Invoke();
            _audio.PlayOneShot(AudioList.Instance.die, 1f);
        }   
    }
}
