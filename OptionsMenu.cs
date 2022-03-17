using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; //main audio for the game controller
    public Slider VolumeSlider; 
    public Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown qualityDropdown;

    Resolution [] resolutions; //resolutions that will be set depending on the device

    async void Start (){
        int qualityLevel = QualitySettings.GetQualityLevel(); //gets the default quality
        qualityDropdown.value= qualityLevel;
        float val = 0f; // stores the current ingame  volume
        audioMixer.GetFloat("mainVolume", out val);
        VolumeSlider.value = val;
        resolutions = Screen.resolutions; 
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResInd =0;

        for (int i=0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResInd = i;
            }

        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResInd;
        resolutionDropdown.RefreshShownValue();
    }
    public void VolumeSetting (float volume)
    {
        audioMixer.SetFloat("mainVolume", volume);
    }
    public void QualitySetting (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
}
