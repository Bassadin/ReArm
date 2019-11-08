using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    public void LoadScene(int level) {
        SceneManager.LoadScene(level);
    }
}
