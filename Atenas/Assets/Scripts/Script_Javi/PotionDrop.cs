using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionDrop : MonoBehaviour
{
    [SerializeField]
    private int _restore;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerShadow"))
        {
            other.gameObject.GetComponentInParent<HealthBehaviour>().GetCure(_restore);
            Destroy(this.gameObject);
        }
    }
}
