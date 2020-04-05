using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Switch : MonoBehaviour
{
    [SerializeField]
    private GameObject _door;
    [SerializeField]
    public Animator _spikeanim;
    [SerializeField]
    public BoxCollider2D _spikebox;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "attackbox")
        {
            _spikeanim.enabled = true;
            _spikebox.enabled = true;
            GameObject.Destroy(_door);
        }
    }
}
