using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousepuzzle : MonoBehaviour
{
    [SerializeField]
    private Transform _objective;
    [SerializeField]
    private GameObject _key;

    private Vector2 _dir;
    private bool _hit = false;
    private HealthBehaviour _healthBehaviour;

    public void Awake()
    {
        _healthBehaviour = GetComponent<HealthBehaviour>();
    }
    
    public void Start()
    {
        _objective = GameObject.Find("Player").transform;
        _dir = (_objective.transform.position - transform.position).normalized;
    }

    private void Update()
    {
        if (!_hit)
        {
            _dir = (_objective.transform.position - transform.position).normalized;
            transform.position = transform.up;
            transform.Rotate(Vector3.Cross(_dir * 5f, transform.position));
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Block")
            _hit = true;
        if (col.name == "attackbox")
        {
            _key.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<mousepuzzle>().enabled = false;
        }
    }
}
