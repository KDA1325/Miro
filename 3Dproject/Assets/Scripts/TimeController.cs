using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textTimer; // 현재 시간 텍스트
    [SerializeField]
    private TextMeshProUGUI recordTimer; // 타이머 기록 텍스트
    private float startTime; // 타이머가 시작했을 때 플레이타임
    private float currentTime; // 타이머 현재 시간(Time.time - time_start)
    //private float maxTime = 5f; // 타이머 최종 시간
    private float recordTime;
    public bool isEnded; // 타이머 종료 확인
    //public bool isEndTimer; // 타이머 종료 확인

    private void Awake()
    {

    }

    private void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        CheckTimer(isEnded);
    }

    private void CheckTimer(bool isEnded) // 타이머 시간 검사
    {
        if(!isEnded) 
        {
            currentTime = Time.time - startTime;

            textTimer.text = $"{currentTime:N2}";
        }
        else
        {
            EndTimer();
        }
    }

    public void EndTimer() // 타이머 종료 시 실행
    {
        //Debug.Log("End");
        recordTime = currentTime;
        recordTimer.text = $"{recordTime:N2}";

        //TimeSpan t = TimeSpan.FromSeconds(recordTime);

        //string record = string.Format("{0:D2}m:{1:D2}s:{2:D2}ms", t.Minutes, t.Seconds, t.Milliseconds);
        //float minute = (recordTime % 3600) / 60;
        //float second = recordTime % 60;
    }


    private void ResetTimer() // 리셋
    {
        startTime = Time.time;
        currentTime = 0;
        recordTime = 0;
        textTimer.text = $"{currentTime:N2}";
        isEnded = false;
        //Debug.Log("Start");
    }
}
