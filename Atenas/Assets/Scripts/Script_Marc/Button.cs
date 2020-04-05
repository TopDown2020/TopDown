
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent OnCollision11;
    public GameObject Shadow_Player;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {


    }//This is for collision
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Box"))
        { 
            OnCollision11.Invoke();
           
        }
    }
}
