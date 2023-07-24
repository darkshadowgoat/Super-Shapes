using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text HighScoreText;

    private void Start()
    {
        HighScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
