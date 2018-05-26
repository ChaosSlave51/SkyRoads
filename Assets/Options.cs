using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Options : MonoBehaviour {

    public GameObject MainMenu;
    // Use this for initialization

    public AudioMixer Mixer;
    private void Start()
    {
      
        
    }
    public void Back() {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void MusicChange(float value)
    {
        Mixer.SetFloat("music", value);
    }
    public void EffectsChange(float value)
    {
        Mixer.SetFloat("effects", value);
    }
}
