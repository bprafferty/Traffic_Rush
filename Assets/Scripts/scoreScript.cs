using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public Text scoreText;
    private void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + gameManaging.gameInstance.savedScore.ToString();
    }
}
