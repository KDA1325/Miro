using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject EndingUI;
    [SerializeField]
    private GameObject IngameUI;

    private void Awake()
    {
        EndingUI.SetActive(false);
        IngameUI.SetActive(true);
    }

    public void EndGame()
    {
        IngameUI.SetActive(false);
        EndingUI.SetActive(true);
    }
}