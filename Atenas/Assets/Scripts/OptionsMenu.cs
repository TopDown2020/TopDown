using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public InputField pname;
    public Slider vol;

    public void Awake()
    {
        pname.text = PlayerPrefs.GetString("Name");
        vol.value = PlayerPrefs.GetFloat("Volume");

    }
    public void SaveOptions()
    {
        PlayerPrefs.SetString("Name", pname.text);
        PlayerPrefs.SetFloat("Volume", vol.value);
        AudioListener.volume = vol.value;
        PlayerPrefs.Save();
    }
}
