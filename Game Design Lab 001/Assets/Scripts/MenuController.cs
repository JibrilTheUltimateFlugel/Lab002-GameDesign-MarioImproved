using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0.0f;
    }
    public void StartButtonClicked() // triggered when the Start Button is clicked
    {
        foreach (Transform canvas in transform)
        {
            foreach (Transform eachChild in canvas)
            {
                if (eachChild.name != "Score") // for all children UI element that is not "Score"
                {
                    Debug.Log("Child found. Name: " + eachChild.name);
                    // disable them, so only Score remains in the UI when game starts
                    eachChild.gameObject.SetActive(false);
                    Time.timeScale = 1.0f;
                }
            }
        }
    }

}
