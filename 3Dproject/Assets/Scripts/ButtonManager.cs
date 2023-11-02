using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ButtonManagerr : MonoBehaviour
{
    [SerializeField]
    private Camera MainCamera;
    [SerializeField]
    private Camera TopViewCamera;
    [SerializeField]
    private MovementCharacterController movementCharacterController;
    private PuzzelController puzzelController;

    private void Start()
    {
        MainCamera.enabled = true;
        TopViewCamera.enabled = false;
        movementCharacterController.isTopView = false;
        puzzelController = GameObject.FindObjectOfType<PuzzelController>();
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

    public void ResetPuzzel()
    {
        puzzelController.ResetPuzzle();
    }
}
