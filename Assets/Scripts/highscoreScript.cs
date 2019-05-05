using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscoreScript : MonoBehaviour
{
    public Text highscoreText;
    private void Start()
    {
        highscoreText.text = "Highscore: " + gameManaging.gameInstance.savedScore.ToString();
    }
}
