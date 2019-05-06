using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscoreScript : MonoBehaviour
{
    public Text highscoreText;
    private void Start()
    {
        highscoreText = GetComponent<Text>();
        if (gameManaging.gameInstance.savedScore > gameManaging.gameInstance.highscore)
        {
            gameManaging.gameInstance.highscore = gameManaging.gameInstance.savedScore;
            PlayerPrefs.SetInt("highscore", gameManaging.gameInstance.savedScore);
        }
        highscoreText.text = "Highscore: " + gameManaging.gameInstance.highscore.ToString();
    }
}
