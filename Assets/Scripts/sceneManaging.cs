using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManaging : MonoBehaviour {
    public Text scoreText;

    private void Start() {
        scoreText.text = gameManaging.gameInstance.savedScore.ToString();
    }
    public void goToNextScene() {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextLevel);
        gameManaging.gameInstance.savedScore++;
    }
    public void goToLevelOne() {
        SceneManager.LoadScene("Test_Scene1");
        gameManaging.gameInstance.savedScore++;
    }
    public void goToMain() {
        SceneManager.LoadScene("Main Menu");
        gameManaging.gameInstance.savedScore = 0;
    }
    public void quitGame() {
        Application.Quit();
    }
}
