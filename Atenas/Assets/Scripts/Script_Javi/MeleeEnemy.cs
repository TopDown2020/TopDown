using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public GameObject player;
    private MoveBehaviour _moveBehaviour;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private AttackBehaviour _attackBehaviour;
    private AudioSource _audioSource;

    [SerializeField]
    private float _rangeDetection;
    
    [SerializeField]
    private float _rangeAttack;
    private float _distance;
    private float _coldown = 2f;
    private float _nextAttack;

    public void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _attackBehaviour = GetComponent<AttackBehaviour>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        _distance = Vector3.Distance(player.transform.position, transform.position);

        if (_distance < _rangeDetection && _distance > _rangeAttack)
        {
            _animator.SetBool("Moving", true);
        }
        else if (_distance < _rangeAttack && Time.time > _nextAttack)
        {
            _nextAttack = Time.time + _coldown;
            _animator.SetTrigger("Attack");
        }
        else
            _animator.SetBool("Moving", false);
        
    }

    void FixedUpdate()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Run") || _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (player.transform.position.x < transform.position.x)
            {
                _spriteRenderer.flipX = true;
                _attackBehaviour.FlipAttack(true);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                _spriteRenderer.flipX = false;
                _attackBehaviour.FlipAttack(false);
            }

            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                _moveBehaviour.Move(new Vector2(player.transform.position.x - transform.position.x,
                                                player.transform.position.y - transform.position.y).normalized);
        }
    }

    public void EnemySound(int sound)
    {
        switch (sound)
        {
            case (1):
                _audioSource.PlayOneShot(AudioList.Instance.enemystep, 0.5f);
                break;
            case (2):
                _audioSource.PlayOneShot(AudioList.Instance.goblinhit, 0.9f);
                break;
            case (3):
                _audioSource.PlayOneShot(AudioList.Instance.goblindeath, 0.5f);
                break;
        }
    }   
}