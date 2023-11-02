using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private TextMeshProUGUI recordText;
    [SerializeField]
    private GameObject ingameUI;
    [SerializeField]
    private GameObject endingUI;

    private float startTime;
    private bool isStarted;
    private bool isCleared;

    void Start()
    {
        isStarted = true;
        isCleared = false;
        startTime = Time.time;
    }

    void Update()
    {
        if (isStarted && !isCleared)
        {
            float elapsedTime = Time.time - startTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
    }

    public void GameClear()
    {
        isStarted = false;
        isCleared = true;

        // 타이머 멈춤
        ingameUI.SetActive(false); // 인게임 UI 비활성화
        endingUI.SetActive(true); // 엔딩 UI 활성화

        // 최종 플레이타임 표시
        float elapsedTime = Time.time - startTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);
        recordText.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, milliseconds);
    }
}
