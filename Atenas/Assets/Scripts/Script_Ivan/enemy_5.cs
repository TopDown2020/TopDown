using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_5 : MonoBehaviour
{
    public bool cantp;

    private HealthBehaviour _healthBehaviour;

    [SerializeField]
    private AudioSource _audio;

    [SerializeField]
    private ParticleSystem _particles;
    [SerializeField]
    private Collider2D wall;
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private GameObject _shotPref;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer; 

    private float _shotCd = 3f;
    private float _tpCd = 4f;

    private float _nextTp;
    private float _nextShot = 0;
    private Vector3 _nextPos;
    
    public void Awake()
    {
        _audio = GetComponent<AudioSource>();

        _healthBehaviour = GetComponent<HealthBehaviour>();

        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _nextTp = Time.time + _tpCd;

        _shotPref.GetComponent<ball_enemy_5>()._objective = _player;
    }

    public void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        //ATTACK ANIMATION
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            _animator.SetBool("Attack", false);
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < 4)
        {
            //FLIP SPRITE
            if (_player.transform.position.x > transform.position.x)
                _spriteRenderer.flipX = false;
            else
                _spriteRenderer.flipX = true;

            //DECIDE IF GET HITBOX AND MOVE OR NOT (IF GETS HIT)
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            {
                _nextTp = 0;
            }
            else
            {
                //ATTACK (RESTARTS CD ON HIT)
                if (Time.time > _nextShot)
                {
                    _animator.SetBool("Attack", true);
                    _nextShot = Time.time + _shotCd;
                    _audio.PlayOneShot(AudioList.Instance.attack, 1f);
                    Instantiate(_shotPref, transform.position + new Vector3(0, 0.2f, 0), transform.rotation);
                }
                //TELEPORT
                else if (Time.time > _nextTp && cantp)
                {
                    _nextTp = Time.time + _tpCd;
                    do
                    {
                        Vector3 random = Random.insideUnitCircle * 2.5f;
                        _nextPos = _player.transform.position + random;
                    } while (wall.bounds.Contains(_nextPos));

                    transform.position = _nextPos;
                    _audio.PlayOneShot(AudioList.Instance.walk, 1f);
                    _particles.Play();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //DIE OR LOWER HEALTH
        if (col.name == "attackbox")
        {
            _audio.PlayOneShot(AudioList.Instance.die, 1f);
            _healthBehaviour.GetHit(1);
        }
    }
}
