using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeViewButton : MonoBehaviour
{
    public Camera MainCamera;
    public Camera TopViewCamera;

    public void ChangeTopView()
    {
        Debug.Log("ž�� ��ȯ");
        MainCamera.enabled = false;
        TopViewCamera.enabled = true;
    }

    public void ChangeBackView()
    {
        Debug.Log("��� ��ȯ");
        TopViewCamera.enabled = false;
        MainCamera.enabled = true;
    }
}
