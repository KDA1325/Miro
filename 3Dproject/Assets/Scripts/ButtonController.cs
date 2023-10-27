using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private Camera MainCamera;
    [SerializeField]
    private Camera TopViewCamera;
    [SerializeField]
    private MovementCharacterController movementCharacterController;
    private CubeController cubeController;

    //private GameObject[] cubes;

    private void Start()
    {
        MainCamera.enabled = true;
        TopViewCamera.enabled = false;
        movementCharacterController.isTopView = false;

        //cubeController = GetComponent<CubeController>();
        //cubes = GameObject.FindGameObjectWithTag("Cube");
        //ResetTransform resetTransform = GetComponent<ResetTransform>();
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
        cubeController.Reset();
    }
    //public void ResetPuzzel()
    //{

    //    foreach (GameObject cube in cubes)
    //    {
    //        CubeController cubeController;
    //        cubeController = cube.GetComponent<ResetTransform>();
    //    }

    //    Debug.Log("���� ����");
    //    //resetTransform.Reset();
    //    //Debug.Log("���� ����");
    //    //// ���� �ҷ����� �����غ���
    //    //resetTransform.Reset();
    //}
}
