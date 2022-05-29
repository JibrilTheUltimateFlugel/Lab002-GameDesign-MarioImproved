using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour
{
    // Sound Effects
    AudioSource marioDeadSFX;

    private void Start()
    {
        marioDeadSFX = GetComponent<AudioSource>();
        marioDeadSFX.Play();
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
