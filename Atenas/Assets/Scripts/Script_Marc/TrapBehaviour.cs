using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    private MoveBehaviour _moveBehaviour;
    private float _speed;
    private GameObject _player;
    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        _moveBehaviour.Move();
    }
       
}
