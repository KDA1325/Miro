using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeViewButton : MonoBehaviour
{
    [SerializeField]
    private Camera MainCamera;
    private Camera TopViewCamera;
    
    public bool isTopView;
    public bool isBackView;

    public void ChangeTopView()
    {
        Debug.Log("ž�� ��ȯ");

        isBackView = false;
        isTopView = true;

        MainCamera.enabled = false;
        TopViewCamera.enabled = true;
    }

    public void ChangeBackView()
    {
        Debug.Log("��� ��ȯ");
        
        isTopView = false;
        isBackView = true;
        
        TopViewCamera.enabled = false;
        MainCamera.enabled = true;
    }
}
