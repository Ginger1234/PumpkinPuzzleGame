using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
   /* [SerializeField] KeyCode keyOne; //vertical 
    [SerializeField] KeyCode keyTwo; //horizontal*/

    [SerializeField] Vector3 movement; //players movement direction 
     [SerializeField] AudioSource ShuffleSound; //sound of moving for objects
    public GameObject loadingScreen;
    public GameObject FinishScreen;

    public Slider LoadSlider;
    public  Text progressText;
    int  direction;
    int numberOfEneteredCubes=0;

     void Start()
    {
        Time.timeScale = 1f; //normal timeflow
       // FinishScreen.SetActive(false);
        //ShuffleSound = GetComponent<AudioSource>(); //sound of moving for objects
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
    

    private void FixedUpdate()
    {
        if ((!ShuffleSound.isPlaying)&&(direction!=0))
        {
           // ShuffleSound.Play(0);//plaing the sound when any of the objects move HAVENT PICKED THE SOUND YET
        }
        GetComponent<Rigidbody>().velocity=movement*direction; //objects movement

//FOR PC
       /* if(Input.GetKey(keyOne))
        {
            //ShuffleSound.Play(0);
            GetComponent<Rigidbody>().velocity+=movement;

        }
        if(Input.GetKey(keyTwo))
        {
            //ShuffleSound.Play(0);
            GetComponent<Rigidbody>().velocity-=movement;

        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //ShuffleSound.Play(0);

        }
        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

        }*/
    }
    public void OnLeftButtonDown()
    {
        direction = -1;//negative direction of  movement
    }
    public void OnRightButtonDown()
    {
        direction = 1; //positive direction of  movement
;
    }
    public void OnButtonUP()
    {
        direction = 0; //no movement
    }
    void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish")) //checking if the player has solved the puzzle
        {
            FinishScreen.SetActive(true);
            PlayerPrefs.SetInt("levelReached", SceneManager.GetActiveScene().buildIndex+1); //changing the number of levels solved
/*
            if(SceneManager.GetActiveScene().buildIndex==8)
            {
                StartCoroutine (LoadAsynchronosly(0));
            }
            else
            {
                StartCoroutine (LoadAsynchronosly(SceneManager.GetActiveScene().buildIndex+1)); //starting the loadinf of the next level
       
            }*/
        }
        if ((this.CompareTag("Cube") && other.CompareTag("Cube"))||(this.CompareTag("Cube") && other.CompareTag("Player"))) //checking if any oblects have entered into the inactive monuments 
        {
            numberOfEneteredCubes+=1;  //number of cubes in one monument
            foreach(ActivationButton button in FindObjectsOfType<ActivationButton>())
            {
                button.canPush = false; //while something is colliding with te monument the button for making it active is unabled 
            }
        }
    }
    //turning everything back on^ if all the objects have exited the monuments
    private void OnTriggerExit(Collider other)
    {
        if ((this.CompareTag("Cube") && other.CompareTag("Cube"))||(this.CompareTag("Cube") && other.CompareTag("Player")))
        {
            numberOfEneteredCubes-=1;
            if(numberOfEneteredCubes==0){
                foreach(ActivationButton button in FindObjectsOfType<ActivationButton>())
                {
                    button.canPush = true;
                }
            }
            
        }
    }

}
