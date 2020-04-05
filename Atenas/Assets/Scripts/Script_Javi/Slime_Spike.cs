using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Spike : MonoBehaviour
{
    [SerializeField]
    private int _damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerShadow"))
        {
            other.gameObject.GetComponentInParent<HealthBehaviour>().GetHit(_damage);
        }
    }
}
