using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneBehaviour : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerShadow"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            if (SceneManager.GetActiveScene().buildIndex == 3)
                GameObject.Find("Main Camera").GetComponent<CameraMove>().End();
        }        
    }
}
