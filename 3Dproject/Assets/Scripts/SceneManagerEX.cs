using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEX : MonoBehaviour
{
    private GameObject EndingUI;
    private GameObject IngameUI;

    private void Awake()
    {
        EndingUI = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        IngameUI = GameObject.Find("IngameUI");

        EndingUI.SetActive(false);
        IngameUI.SetActive(true);
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

    public void EndGame()
    {
        IngameUI.SetActive(false);
        EndingUI.SetActive(true);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(1);
    }
}
