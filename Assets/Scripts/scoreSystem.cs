using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreSystem : MonoBehaviour
{
    public Text scoreDisplay;
    public Text HIscoreDisplay;

    private float score;

    public void Start()
    {
        scoreDisplay.text = (PlayerPrefs.GetInt("Score", 0).ToString());

        score = PlayerPrefs.GetInt("Score", 0);

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
        }

        HIscoreDisplay.text = (PlayerPrefs.GetInt("HighScore", 0).ToString());
    }
}
