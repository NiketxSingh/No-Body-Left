using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [Header("-------Audio Source-------")]

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("-------Audio Clip-------")]

    public AudioClip background;
    public AudioClip blade_death;
    public AudioClip blast_death;
    public AudioClip ghost;
    public AudioClip door;
    public AudioClip get_key;
    public AudioClip get_scroll;
    public AudioClip use_scroll;

    private static AudioManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else {
            Destroy(gameObject); 
        }
    }

    private void Start() {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) {
        sfxSource.PlayOneShot(clip);
    }
}