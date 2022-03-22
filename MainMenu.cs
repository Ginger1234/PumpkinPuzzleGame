using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer; //main audio for the game controller

    void Start()
    {
        audioMixer.SetFloat("mainVolume", PlayerPrefs.GetFloat("VolumePrefs", 1f));
    }
    /*
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }*/
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit ();
    }
}
