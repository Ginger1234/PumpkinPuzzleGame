using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class FinishScreen : MonoBehaviour
{
    public GameObject loadingScreen;
    //public GameObject Thisscreen;

    public Slider LoadSlider;
    public  Text progressText;
    public Button[] NavButtons;



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f; //makes the ingame time stop
        for (int i=0; i<NavButtons.Length; i++){ //makes player navigation buttons not pressable
            NavButtons[i].interactable = false;
        }
    }
    public void restartLevel()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
        Time.timeScale = 1f; //makes the ingame time go back to real
        for (int i=0; i<NavButtons.Length; i++){ //makes player navigation buttons  pressable
            NavButtons[i].interactable = true;
        }
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
    public void NextLevel()
    {
        //PlayerPrefs.SetInt("levelReached", SceneManager.GetActiveScene().buildIndex+1); //changing the number of levels solved

            if(SceneManager.GetActiveScene().buildIndex==8)
            {
                StartCoroutine (LoadAsynchronosly(0));
            }
            else
            {
                StartCoroutine (LoadAsynchronosly(SceneManager.GetActiveScene().buildIndex+1)); //starting the loadinf of the next level
       
            }
    }

}
