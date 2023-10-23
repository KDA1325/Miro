using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textTimer; // ���� �ð� �ؽ�Ʈ
    private float startTime; // Ÿ�̸Ӱ� �������� �� �÷���Ÿ��
    private float currentTime; // Ÿ�̸� ���� �ð�(Time.time - time_start)
    //private float maxTime = 5f; // Ÿ�̸� ���� �ð�
    private bool isEnded; // Ÿ�̸� ���� Ȯ��

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

    private void CheckTimer() // Ÿ�̸� �ð� �˻�
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

    private void EndTimer() // Ÿ�̸� ���� �� ����
    {
        Debug.Log("End");
        //currentTime = maxTime;
        textTimer.text = $"{currentTime:N2}";
        isEnded = true;
    }


    private void ResetTimer() // ����
    {
        startTime = Time.time;
        currentTime = 0;
        textTimer.text = $"{currentTime:N2}";
        isEnded = false;
        Debug.Log("Start");
    }
}
