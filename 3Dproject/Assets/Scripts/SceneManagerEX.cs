using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEX : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(1);
    }
}
