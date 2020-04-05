using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
    private PolygonCollider2D[] _attackBox;
    private bool _fliped = false;

    public void Awake()
    {
        _attackBox = GetComponentsInChildren<PolygonCollider2D>();
        foreach (PolygonCollider2D attack in _attackBox)
           attack.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("attack"))
        {
            for (int i = 0 ; i < _attackBox.Length ; i++)
                _attackBox[i].enabled = false;
        }
    }

    public void FlipAttack(bool fliped)
    {
        _fliped = fliped;
    }

    public void AttackEvent(AnimationEvent animEvent)
    {
        if (animEvent.animatorClipInfo.weight > 0.5f)
        {
            animEvent.intParameter = _fliped ? _attackBox.Length-1 : animEvent.intParameter;
            _attackBox[animEvent.intParameter].enabled = !_attackBox[animEvent.intParameter].enabled;
        }
    }

    public void Attack(int activate)
    {
        if (_fliped)
            _attackBox[1].enabled = activate == 1 ? true:false;
        else
            _attackBox[0].enabled = activate == 1 ? true:false;
    }
}