using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool paused=false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Resume();
            }
            else
            {
                pauseMenu.SetActive(true);
                paused = true;
                Time.timeScale=0f;
                Cursor.visible=true;
                Cursor.lockState=CursorLockMode.None;
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        paused =false;
        Time.timeScale=1f;
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;
    }
}
