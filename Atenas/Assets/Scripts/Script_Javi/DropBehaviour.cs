using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBehaviour : MonoBehaviour
{
    public GameObject HealthPotion;
    private float _ratio;

    public void Drop()
    {
        _ratio = Random.Range(0.1f, 1.1f);

        if (_ratio > 0.8)
        {
            Instantiate(HealthPotion, transform.position, Quaternion.identity);
        }
    }
}
