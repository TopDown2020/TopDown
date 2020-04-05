using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MoveBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector2 _direction;

    [SerializeField]
    private float _speed;
    public float Speed { get => _speed; set => _speed = value; }

    private Rigidbody2D _rb;


    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Move()
    {
        _rb.MovePosition(new Vector2(transform.position.x + _direction.x * _speed * Time.deltaTime,
                                     transform.position.y + _direction.y * _speed * Time.deltaTime));
    }
    public void Move(Vector2 newDir)
    {
        _rb.MovePosition(new Vector2(transform.position.x + newDir.x * _speed * Time.deltaTime,
                                     transform.position.y + newDir.y * _speed * Time.deltaTime));
    }
}
