using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class LevelMenu : MonoBehaviour
{
    public Button[] levelButtons; 
   public Slider LoadSlider;
    public  Text progressText; //precent of the next screen's loading
    public GameObject loadingScreen;


    async void Start ()
    {
        int levelReached = PlayerPrefs.GetInt ("levelReached", 1); //saved number of levels passed by player(defaults to 1)
        for (int i =0; i < levelButtons.Length; i++) //changing the interactebility of the buttons 
        {
            if ((i+1)>levelReached)
                levelButtons[i].interactable = false;
        }
    }

    IEnumerator LoadAsynchronosly (int sceneIndex) //loading next scene while the current one is playing
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/ .9f); //because unity goes from 0.9 to 1 separetly. do this so the 1 (100%) will appear on loading bar too
            LoadSlider.value = progress;
            Debug.Log(Math.Ceiling(progress*100));
            progressText.text = Math.Ceiling(progress*100f) +"%";
            yield return null;
        }
    }
    public void loadLevel(int sceneIndex)
    {
        StartCoroutine (LoadAsynchronosly(sceneIndex));
    }
/*
    public void Select(int levelName)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+levelName);
    }*/
    public void ResetProgress()
    {
        PlayerPrefs.SetInt("levelReached", 1);
        Start ();
    }

}
