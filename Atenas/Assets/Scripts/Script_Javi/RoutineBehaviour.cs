
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutineBehaviour : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _routes;
    [SerializeField]
    private bool _pingPong;
    private MoveBehaviour _moveBehaviour;
    private int _next = 0;



    public void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
    }


    public void Route(Vector3 pos)
    {
        if (Vector3.Distance(_routes[_next].position, pos) < 0.1f)
        {
            if (_next == _routes.Count-1)
            {
                if (_pingPong)
                    _routes.Reverse();
                _next = 0;
            }
            else
            {
                _next++;
            }
        }
        else
        {
            _moveBehaviour.Move(new Vector2(_routes[_next].position.x - pos.x, _routes[_next].position.y - pos.y).normalized);
        }
    }
}