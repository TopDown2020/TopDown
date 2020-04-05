using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class key : MonoBehaviour
{
    [SerializeField]
    private GameObject _door;
    [SerializeField]
    private GameObject _nextRoom;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            AudioSource audio = GetComponent<AudioSource>();
            _door.SetActive(false);
            _nextRoom.SetActive(true);
            audio.PlayOneShot(audio.clip, 1f);
            Destroy(transform.parent.gameObject);
        }
    }
}
