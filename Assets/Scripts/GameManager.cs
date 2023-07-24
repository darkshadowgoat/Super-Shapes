using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    public Text scoreCounter;
    public int score = 0;

    [Header("Collectables")]
    public Collectable collectable;
    public Text collectableCounter;
    public int collectableCount = 0;
    public GameObject collectableParticleSystem;

    [Header("Color Switching")]
    public Color[] colors;
    public Camera MainCamera;
    public int colorNumber;

    [Header("Camera Zooming")]
    public float zoomTimer = 0.25f;
    public float cameraOrignalValue = 5f;
    public float cameraZoomedValue = 4f;

    [Header("Highscore")]
    public Text highScoreCounter;

    void Start()
    {
        scoreCounter.text = score.ToString();
        highScoreCounter.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        collectableCounter.text = collectableCount.ToString();
        colorNumber = Random.Range(0, colors.Length);
        MainCamera.backgroundColor = colors[colorNumber];
    }

    void Update()
    {
        colorNumber = Random.Range(0, colors.Length);
    }

    public IEnumerator CameraZoomer()
    {
        MainCamera.orthographicSize = cameraZoomedValue;
        yield return new WaitForSeconds(zoomTimer);
        MainCamera.orthographicSize = cameraOrignalValue;
    }

    public void IncreaseScore()
    {
        score++;
        scoreCounter.text = score.ToString();
        MainCamera.backgroundColor = colors[colorNumber];
        StartCoroutine(CameraZoomer());
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreCounter.text = score.ToString();
        }
    }

    public void IncreaseCollectable()
    {
        collectableCount++;
        collectableCounter.text = collectableCount.ToString();
    }
}
