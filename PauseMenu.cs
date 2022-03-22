using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class PauseMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider LoadSlider;
    public  Text progressText;

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public void restartLevel()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }

    public void loadLevel(int sceneIndex)//for the loading of the menu
    {
        StartCoroutine (LoadAsynchronosly(sceneIndex));

    }
     IEnumerator LoadAsynchronosly (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/ .9f); 
            LoadSlider.value = progress;
            progressText.text = Math.Ceiling(progress*100f) +"%";
            yield return null;
        }
    }
    public void QuitGame()
    {
        Application.Quit(); //quitting the game
    }
}
