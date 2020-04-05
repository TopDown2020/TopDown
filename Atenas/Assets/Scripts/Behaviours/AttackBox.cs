using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    [SerializeField]
    private int _damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.CompareTag("attack"))
            other.gameObject.GetComponent<HealthBehaviour>().GetHit(_damage);
    }
}
