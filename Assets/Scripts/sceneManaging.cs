using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManaging : MonoBehaviour {
    public Text scoreText;
    public int currentScore = 0;


    public GameObject pauseMenu;

    void Update() {
<<<<<<< HEAD
        scoreText.text = gameManaging.gameInstance.savedScore.ToString();
        //if (SceneManager.GetActiveScene().name == "Test_Scene1"){

        //}


        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Main Menu"){
=======
        
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Main Menu") {
>>>>>>> 88cea6594420f6037c41c786ad970de879ff6427
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
            Debug.Log("Time is: " + Time.timeScale);
            StopCoroutine(scoreTimer());
        }
        if (pauseMenu.activeSelf == false && SceneManager.GetActiveScene().name != "Main Menu") {
            StartCoroutine(scoreTimer());
        }

    }

    private IEnumerator scoreTimer() {
        while (SceneManager.GetActiveScene().name != "Main Menu") {
            gameManaging.gameInstance.savedScore += 1;
            yield return new WaitForSecondsRealtime(100.0f);
        }
    }

    public void setTime(){
        Time.timeScale = 1.0f;
        Debug.Log("Time is: " + Time.timeScale);
    }

<<<<<<< HEAD
    private void Start() {
        
=======
    private void Start() {
        scoreText.text = gameManaging.gameInstance.savedScore.ToString();
>>>>>>> 88cea6594420f6037c41c786ad970de879ff6427
    }


    public void goToNextScene() {
        gameManaging.gameInstance.savedScore = 0;
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextLevel);
        //gameManaging.gameInstance.savedScore++;
    }

    public void goToLevelOne() {
        SceneManager.LoadScene("Test_Scene1");
        //gameManaging.gameInstance.savedScore++;
    }

    public void goToMain() {
        SceneManager.LoadScene("Main Menu");
    }

    public void quitGame() {
        Application.Quit();
    }
}
