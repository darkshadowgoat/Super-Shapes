using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [Header("Scene Names")]
    public string menuSceneName;
    public string gameSceneName;
    public string storeSceneName;
    public string settingSceneName;

    [Header("Game Over")]
    public GameObject gameOverCanvas;
    public GameObject player;
    public bool isGameOver;

    [Header("Pause Game")]
    public GameObject pauseGameCanvas;
    public bool isGamePaused;

    [Header("Audio Manager")]
    public AudioManager audioManager;

    public void GoToMenu()
    {
        audioManager.OnUIButtonClick("buttonClick");
        SceneManager.LoadScene(menuSceneName);
    }

    public void GoToGame()
    {
        bool onButtonClick;
        audioManager.OnUIButtonClick("buttonClick");
        isGameOver = false;
        onButtonClick = true;
        if (onButtonClick)
        {
            SceneManager.LoadScene(gameSceneName);
            onButtonClick = false;
        }
    }

    public void GoToStore()
    {
        audioManager.OnUIButtonClick("buttonClick");
        SceneManager.LoadScene(storeSceneName);
    }

    public void GoToSettings()
    {
        audioManager.OnUIButtonClick("buttonClick");
        SceneManager.LoadScene(settingSceneName);
    }
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        player.SetActive(false);
        isGameOver = true;
        //audioManager.OnUIButtonClick("buttonClick");
    }

    public void PauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused == true && !isGameOver)
        {
            pauseGameCanvas.SetActive(true);
            Time.timeScale = 0;
            audioManager.OnUIButtonClick("buttonClick");
        }
        else
        {
            pauseGameCanvas.SetActive(false);
            Time.timeScale = 1;
            audioManager.OnUIButtonClick("buttonClick");
        }
    }

    public void PauseBackButton()
    {
        isGamePaused = false;
        pauseGameCanvas.SetActive(false);
        Time.timeScale = 1;
        audioManager.OnUIButtonClick("buttonClick");
    }
}
