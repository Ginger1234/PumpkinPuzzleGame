using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavButtons : MonoBehaviour
{
    public GameObject[] ZObjects;//cubes moving on Z axis
    public GameObject[] XObjects; //cubes moving on X axis
    [SerializeField] Vector3 movement; //players movement direction

    public async void OnButtonDown()
    {
        for(int i =0; i< ZObjects.Length; i++){
            //Debug.Log(ZObjects[i].GetComponent<Rigidbody>().velocity);
            ZObjects[i].GetComponent<Rigidbody>().velocity = movement;
        }
        for(int i =0; i< XObjects.Length; i++){
            //Debug.Log(XObjects[i].GetComponent<Rigidbody>().velocity);
            XObjects[i].GetComponent<Rigidbody>().velocity = movement;
        }

    }
}
