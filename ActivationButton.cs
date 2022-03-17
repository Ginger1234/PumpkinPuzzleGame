using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationButton : MonoBehaviour
{
    public GameObject[] firstGroup;
    public GameObject[] secondGroup;
    public Material monumentsNormal;
    AudioSource PressingSound;
    


    public ActivationButton button;
    public Material normal;
    public Material transparent;
    public bool canPush;
    
    void Start()
    {
        PressingSound = GetComponent<AudioSource>();
    }
    


    private void OnTriggerEnter(Collider other)
    {

        if(canPush){

            if(other.CompareTag("Cube") || other.CompareTag("Player"))
            {
                PressingSound.Play(0);
                foreach(GameObject first in firstGroup)
                {
                    first.GetComponent<Renderer>().material = normal;
                    GameObject monument = first.transform.Find("Monument").gameObject;
                    monument.GetComponent<Collider>().isTrigger = false;
                    monument.GetComponentInChildren<Renderer>().material = monumentsNormal;
                    GameObject light = monument.transform.Find("Light").gameObject;
                    light.GetComponent<Light>().enabled = true;
                    first.GetComponent<Collider>().isTrigger = false;

                }
                foreach(GameObject second in secondGroup)
                {
                    second.GetComponent<Renderer>().material = transparent;
                    GameObject monument = second.transform.Find("Monument").gameObject;
                    monument.GetComponent<Collider>().isTrigger = true;
                    monument.GetComponentInChildren<Renderer>().material = transparent;
                    GameObject light = monument.transform.Find("Light").gameObject;
                    light.GetComponent<Light>().enabled = false;
                    second.GetComponent<Collider>().isTrigger = true;
                }
                GetComponent<Renderer>().material = transparent;
                button.GetComponent<Renderer>().material = normal;
                GetComponent<Renderer>().material = transparent;

                GameObject ThisCandle = this.transform.Find("Candle").gameObject;
                ThisCandle.GetComponentInChildren<Renderer>().material = transparent;
                GameObject Thislight2 = ThisCandle.transform.Find("Light").gameObject;
                Thislight2.GetComponent<Light>().enabled = false;

                GameObject candle = button.transform.Find("Candle").gameObject;
                candle.GetComponentInChildren<Renderer>().material = normal;
                GameObject light2 = candle.transform.Find("Light").gameObject;
                light2.GetComponent<Light>().enabled = true;
                button.canPush = true;
                canPush = false;
            }
        }
        
    }
    
}
