using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public Slider vol;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        vol.value = PlayerPrefs.GetFloat("Volume");
    }
    public void ChangeVol()
    {
        PlayerPrefs.SetFloat("Volume", vol.value);
        AudioListener.volume = vol.value;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    public void GoMainMenu()
    {
        Time.timeScale = 1;
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("TrailEffect"));
        Destroy(GameObject.Find("HUD"));
        Destroy(this.gameObject);
        SceneManager.LoadScene("Title_Menu");
    }
}