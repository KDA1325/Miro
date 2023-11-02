using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textTimer; // ���� �ð� �ؽ�Ʈ
    [SerializeField]
    private TextMeshProUGUI recordTimer; // Ÿ�̸� ��� �ؽ�Ʈ
    private float startTime; // Ÿ�̸Ӱ� �������� �� �÷���Ÿ��
    private float currentTime; // Ÿ�̸� ���� �ð�(Time.time - time_start)
    //private float maxTime = 5f; // Ÿ�̸� ���� �ð�
    private float recordTime;
    public bool isEnded; // Ÿ�̸� ���� Ȯ��
    //public bool isEndTimer; // Ÿ�̸� ���� Ȯ��

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

    private void CheckTimer(bool isEnded) // Ÿ�̸� �ð� �˻�
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

    public void EndTimer() // Ÿ�̸� ���� �� ����
    {
        //Debug.Log("End");
        recordTime = currentTime;
        recordTimer.text = $"{recordTime:N2}";

        //TimeSpan t = TimeSpan.FromSeconds(recordTime);

        //string record = string.Format("{0:D2}m:{1:D2}s:{2:D2}ms", t.Minutes, t.Seconds, t.Milliseconds);
        //float minute = (recordTime % 3600) / 60;
        //float second = recordTime % 60;
    }


    private void ResetTimer() // ����
    {
        startTime = Time.time;
        currentTime = 0;
        recordTime = 0;
        textTimer.text = $"{currentTime:N2}";
        isEnded = false;
        //Debug.Log("Start");
    }
}
