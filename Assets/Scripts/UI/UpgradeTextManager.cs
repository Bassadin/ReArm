using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTextManager : MonoBehaviour
{
    private static UpgradeTextManager _instance;

    public static UpgradeTextManager Instance { get { return _instance; } }

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

    public void setUpgradeLevelToDisplay(int scoreToAdd)
    {
        Debug.Assert(scoreToAdd >= 0);
        scoreText.text = scoreToAdd.ToString();
    }
}
