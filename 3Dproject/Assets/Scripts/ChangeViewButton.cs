using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeViewButton : MonoBehaviour
{
    [SerializeField]
    private Camera MainCamera;
    [SerializeField]
    private Camera TopViewCamera;
    [SerializeField]
    private MovementCharacterController movementCharacterController;

    private void Start()
    {
        MainCamera.enabled = true;
        TopViewCamera.enabled = false;
        movementCharacterController.isTopView = false;
    }

public void ChangeTopView()
    {
        Debug.Log("ž�� ��ȯ");

        MainCamera.enabled = false;
        TopViewCamera.enabled = true;
        movementCharacterController.isTopView = true;
    }

    public void ChangeBackView()
    {
        Debug.Log("��� ��ȯ");
        
        TopViewCamera.enabled = false;
        MainCamera.enabled = true;
        movementCharacterController.isTopView = false;
    }
}
