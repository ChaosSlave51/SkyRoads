using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour {

    public GameObject MainMenu;
    // Use this for initialization

    public AudioMixer Mixer;

    Resolution[] _resolutions;
    string[] _qualities;

    public TMP_Dropdown QualityDropdown;
    public TMP_Dropdown ResolutionsDropdown;
    public TMP_Dropdown FullScreeenDropdown;

    public Slider Music;
    public Slider Effects;

    private void Start() //todo set current resolution
    {

        PrepQuality();
        PrepResoltion();
        PrepScreenSize();

        PrepSound();
    }

    private void PrepSound()
    {
        float music = 0;
        if (Mixer.GetFloat("music", out music))
        {
            Music.value = music;
        }
        float effects = 0;
        if (Mixer.GetFloat("effects", out effects))
        {
            Effects.value = effects;
        }
    }

    private void PrepResoltion()
    {
        _resolutions = Screen.resolutions;
        ResolutionsDropdown.ClearOptions();
        var options = new List<string>();
        int currentResolutiojnIndex = 0;
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = string.Format("{0} x {1}", _resolutions[i].width, _resolutions[i].height);
            options.Add(option);
            if (_resolutions[i].width == Screen.width && _resolutions[i].height == Screen.height)
            {
                currentResolutiojnIndex = i;
            }
        }
        ResolutionsDropdown.AddOptions(options);
        ResolutionsDropdown.value = currentResolutiojnIndex;
        ResolutionsDropdown.RefreshShownValue();
    }
    private void PrepQuality()
    {
        _qualities = QualitySettings.names;
        QualityDropdown.ClearOptions();

        QualityDropdown.AddOptions(_qualities.ToList());
        QualityDropdown.value = QualitySettings.GetQualityLevel();
        QualityDropdown.RefreshShownValue();
    }
    private void PrepScreenSize()
    {
        switch (Screen.fullScreenMode)
        {
            case FullScreenMode.Windowed:
                FullScreeenDropdown.value = 0;
                break;
            case FullScreenMode.MaximizedWindow:
                FullScreeenDropdown.value = 1;
                break;
            case FullScreenMode.FullScreenWindow:
                FullScreeenDropdown.value = 3;
                break;
   

        }



        FullScreeenDropdown.RefreshShownValue();
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

    public void QualityChange(int quality)//todo set current resolution
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void FullScreenChange(int fullScreen)//0- windowed 1-borderless 2 full screen //todo set current resolution
    {
        if (fullScreen == 0)
        {
            //Screen.fullScreenMode = FullScreenMode.Windowed;

            Screen.SetResolution(_resolutions[ResolutionsDropdown.value].width, _resolutions[ResolutionsDropdown.value].height, FullScreenMode.Windowed);
        }
        else if (fullScreen == 1)
        {
            //Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
            Screen.SetResolution(_resolutions[ResolutionsDropdown.value].width, _resolutions[ResolutionsDropdown.value].height, FullScreenMode.MaximizedWindow);
        }
        else if (fullScreen == 2)
        {
            //Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            Screen.SetResolution(_resolutions[ResolutionsDropdown.value].width, _resolutions[ResolutionsDropdown.value].height, FullScreenMode.FullScreenWindow);
        }
        
    }
    public void ResolutionChange(int resolutionId)
    {
        Screen.SetResolution(_resolutions[resolutionId].width, _resolutions[resolutionId].height, Screen.fullScreenMode);
    }

}
