using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorj : MonoBehaviour
{
    public Chestj chest;
    private Animator _animator;
    private bool _openable = false;
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    public GameObject key;

    public void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        key = GameObject.Find("Inventory").transform.GetChild(0).gameObject;
    }

    private void OnEnable()
    {
        chest.OnOpen += Unlock;
    }

    private void OnDisable()
    {
        chest.OnOpen -= Unlock;
    }

    private void Unlock()
    {
        _openable = true;
        key.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerShadow") && _openable && Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            _audioSource.clip = AudioList.Instance.opendoor_chest;
            _audioSource.Play();
            _animator.SetBool("Open", true);
            _boxCollider.enabled = false;
            key.SetActive(false);
        }
    }
}
