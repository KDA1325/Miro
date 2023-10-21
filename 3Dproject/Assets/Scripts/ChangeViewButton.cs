using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeViewButton : MonoBehaviour
{
    public Camera MainCamera;
    public Camera TopViewCamera;

    public void ChangeTopView()
    {
        Debug.Log("Å¾ºä ÀüÈ¯");
        MainCamera.enabled = false;
        TopViewCamera.enabled = true;
    }

    public void ChangeBackView()
    {
        Debug.Log("¹éºä ÀüÈ¯");
        TopViewCamera.enabled = false;
        MainCamera.enabled = true;
    }
}
