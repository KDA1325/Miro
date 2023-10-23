using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textTimer; // 현재 시간 텍스트
    private float startTime; // 타이머가 시작했을 때 플레이타임
    private float currentTime; // 타이머 현재 시간(Time.time - time_start)
    //private float maxTime = 5f; // 타이머 최종 시간
    private bool isEnded; // 타이머 종료 확인

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ResetTimer();
    }
    void Update()
    {
        if (isEnded)
            return;

        CheckTimer();
    }

    private void CheckTimer() // 타이머 시간 검사
    {
        currentTime = Time.time - startTime;

        textTimer.text = $"{currentTime:N2}";
        Debug.Log(currentTime);

        //if (currentTime < maxTime)
        //{
        //    textTimer.text = $"{currentTime:N2}";
        //    Debug.Log(currentTime);
        //}
        //else if (!isEnded)
        //{
        //    EndTimer();
        //}
    }

    private void EndTimer() // 타이머 종료 시 실행
    {
        Debug.Log("End");
        //currentTime = maxTime;
        textTimer.text = $"{currentTime:N2}";
        isEnded = true;
    }


    private void ResetTimer() // 리셋
    {
        startTime = Time.time;
        currentTime = 0;
        textTimer.text = $"{currentTime:N2}";
        isEnded = false;
        Debug.Log("Start");
    }
}
