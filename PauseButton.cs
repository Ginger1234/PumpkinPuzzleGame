using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public static bool GameIsPaused = false; 
    public Button[] NavButtons;

    public async void OnButtonDown()
    {
        if (GameIsPaused)
            {
                Resume();
            }
            else{
                Pause();
            }
    }
    public async void Resume()
    {
        
        PauseMenuUI.SetActive(false); //shows pause menu
        Time.timeScale = 1f; //makes the ingame time pass as real time
        GameIsPaused = false; 
        for (int i=0; i<NavButtons.Length; i++){ //makes player navigation buttons pressable
            NavButtons[i].interactable = true;
        }
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true); //hides pause menu
        
        Time.timeScale = 0f; //makes the ingame time stop
        GameIsPaused = true;
        for (int i=0; i<NavButtons.Length; i++){ //makes player navigation buttons not pressable
            NavButtons[i].interactable = false;
        }
    }
}
