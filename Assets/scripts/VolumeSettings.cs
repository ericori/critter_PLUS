using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider; // access slider
    [SerializeField] private Slider SFXSlider; // access SFX slider
    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();      
        }
        else
        {
            SetMusicVolume();
        }
    }

    //allow slider
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20); // gives us control to change with slider
        PlayerPrefs.SetFloat("musicVolume", volume); // Sets player preference to save settings
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20); // gives us control to change with slider
        PlayerPrefs.SetFloat("SFXVolume", volume); // Sets player preference to save settings
    }
    //Saves player pref
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
    }


}
