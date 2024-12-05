using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("========= AUDIO SOURCE ========")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("========= AUDIO CLIP ========")]
    public AudioClip ThemeSong;
    public AudioClip dogBark;
    public AudioClip dogBarks;
    public AudioClip levelUp;
    public AudioClip full;
    public SubtitleManager subtitleManager;


    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("This is your initial instance!");
        }
        else
        {
            Debug.Log("Destroying Duplicate instance I found");
            Destroy(gameObject);
        }
    }
    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}
    private void Start()
    {
        musicSource.clip = ThemeSong;
        musicSource.Play();

    }

    //Takes audioclips as param and play any sound wanted
    public void PlaySFX(AudioClip clip, int subtitleIndex, float duration)
    {
        SFXSource.PlayOneShot(clip);
        if (subtitleManager != null)
        {
            subtitleManager.DisplaySubtitle(subtitleIndex, duration);
        }
    }
}
