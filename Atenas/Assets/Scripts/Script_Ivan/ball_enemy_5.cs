using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_enemy_5 : MonoBehaviour
{
    private MoveBehaviour _moveBehaviour;
    private HealthBehaviour _healthBehaviour;

    public Transform _objective;

    private Vector2 _dir;
    private Vector3 _startPos;
    public void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _healthBehaviour = GetComponent<HealthBehaviour>();

        _startPos = transform.position;
        
    }

    public void Start()
    {
        _objective = GameObject.Find("Player").transform;
        _dir = (_objective.transform.position - transform.position).normalized;
    }
    void FixedUpdate()
    {
        _moveBehaviour.Move(_dir);
        if (Vector3.Distance(transform.position, _startPos) > 15)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name != "Holes" && col.name != "MapCollider")
            _healthBehaviour.GetHit(1);
    }
}
