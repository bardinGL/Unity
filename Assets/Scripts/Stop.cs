using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                // Pause the game
                Time.timeScale = 0f;
            }
            else
            {
                // Unpause the game
                Time.timeScale = 1f;
            }
        }
    }
}