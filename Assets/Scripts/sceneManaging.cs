using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManaging : MonoBehaviour {
    public Text scoreText;

    public GameObject pauseMenu;

    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Main Menu") {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
            Debug.Log("Time is: " + Time.timeScale);
        }

    }

    public void setTime(){
        Time.timeScale = 1.0f;
        Debug.Log("Time is: " + Time.timeScale);
    }

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
