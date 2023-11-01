using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEX : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }

    public void EndGame()
    {
        GameObject Ending = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        Ending.SetActive(true);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(1);
    }
}
