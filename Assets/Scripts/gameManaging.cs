using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManaging : MonoBehaviour {
    public static gameManaging gameInstance {
        get;
        private set;
    }

    public int savedScore;
    public int highscore;

    private void Awake() {
        if (gameInstance == null) {
            Debug.Log("Saved Score is " + savedScore);
            gameInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        Debug.Log("Highscore is " + highscore);
    }
}