using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviour : MonoBehaviour
{
    public Image HPbar;

    [SerializeField]
    private int _maxHealth;
    private int _health;
    [SerializeField]
    private bool _inmune = false;
    private Animator _animator;

    public void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = _maxHealth;

        if (HPbar == null && this.gameObject.CompareTag("Player"))
        {
            HPbar = GameObject.Find("Lifebar").GetComponent<Image>();
            HPbar.fillAmount = (float)_health / (float)_maxHealth;
        }
    }

    public void GetHit(int damage)
    {
        if (_health > 0 && !_inmune)
        {
            _health -= damage;
            if (_health <= 0)
            {
                _health = 0;
                _animator.SetTrigger("Death");
            }
            else
                _animator.SetTrigger("Hit");

            if (HPbar != null)
                HPbar.fillAmount = (float)_health / (float)_maxHealth;
        }
    }

    public void GetCure(int restore)
    {
        if (_health < _maxHealth)
        {
            _health += restore;
            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
            HPbar.fillAmount = (float)_health / (float)_maxHealth;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }


    public void Grounded()
    {
        GetComponent<DropBehaviour>().Drop();

        GetComponent<BoxCollider2D>().enabled = false;
        _animator.enabled = false;

        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            Destroy(script);
        }

        for (int num = transform.childCount-1 ; num >= 0 ; num--)
        {
            Transform child = transform.GetChild(num);
            child.gameObject.SetActive(false);
        }
    }
}