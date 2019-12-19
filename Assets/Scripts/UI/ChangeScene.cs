using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(int level) {
        SceneManager.LoadScene(level);
    }

    public void LoadSceneAndClearLastScore(int level) {
        StaticGameInfo.setLastGameScore(0);
        LoadScene(level);
    }
}
