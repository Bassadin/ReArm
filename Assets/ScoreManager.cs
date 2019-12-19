using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    private static ScoreManager _instance;

    public static ScoreManager Instance { get { return _instance; } }

    private Text scoreText;

    private void Awake()
    {
        scoreText = gameObject.GetComponent<Text>();
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public int getScore() {
        return score;
    }

    public void addScore(int scoreToAdd) {
        Debug.Assert(scoreToAdd > 0);
        score += scoreToAdd;
        scoreText.text = this.getScore().ToString();
    }
}
