using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    private MoveBehaviour _moveBehaviour;
    //private FollowBehaviour _followBehaviour;
    private SpriteRenderer _spriterenderer;
    public GameObject target;
    public GameObject target2;
    private Vector3 diff;
    public float visionRad;
    public float dist;
    public bool life =true;

    void Start()
    {
        target = GameObject.Find("Player");
        _moveBehaviour = GetComponent<MoveBehaviour>();
        //_followBehaviour = GetComponent<FollowBehaviour>();
        _spriterenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        
        dist = Vector3.Distance(target.transform.position, transform.position);
        if (visionRad> dist)
        {
            diff = (transform.position - target.transform.position).normalized;
            _moveBehaviour.Move(-diff);
            if(diff.x<0)
            {
                _spriterenderer.flipX = false;
            }
            else
            {
                _spriterenderer.flipX = true;
            }
        }
        else
        {
            diff = (transform.position - target2.transform.position).normalized;
            _moveBehaviour.Move(-diff);
            if (diff.x<=0)
            {
                _spriterenderer.flipX = false;
            }
        }
   
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRad);
    }

    
}