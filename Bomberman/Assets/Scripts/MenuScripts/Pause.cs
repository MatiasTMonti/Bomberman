using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool gameIsPause = false;

    [SerializeField] private GameObject pauseMenuUI;

    private void Update()
    {
        PauseInput();
    }

    private void PauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                ResumeScene();
            }
            else
            {
                PauseScene();
            }
        }
    }

    public void ResumeScene()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }

    public void PauseScene()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }
}
