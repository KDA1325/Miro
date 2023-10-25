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
    [SerializeField]
    private GameObject[] cubes;

    private void Start()
    {
        MainCamera.enabled = true;
        TopViewCamera.enabled = false;
        movementCharacterController.isTopView = false;
        //cubes = GameObject.FindGameObjectWithTag("Cube");
        //ResetTransform resetTransform = GetComponent<ResetTransform>();
    }

    public void ChangeTopView()
    {
        Debug.Log("탑뷰 전환");

        MainCamera.enabled = false;
        TopViewCamera.enabled = true;
        movementCharacterController.isTopView = true;
    }

    public void ChangeBackView()
    {
        Debug.Log("백뷰 전환");
        
        TopViewCamera.enabled = false;
        MainCamera.enabled = true;
        movementCharacterController.isTopView = false;
    }

    public void ResetPuzzel()
    {

        foreach (GameObject cube in cubes)
        {
            ResetTransform resetTransform;
            resetTransform = cube.GetComponent<ResetTransform>();
        }

        Debug.Log("퍼즐 리셋");
        //resetTransform.Reset();
        //Debug.Log("퍼즐 리셋");
        //// 어케 불러올지 생각해보기
        //resetTransform.Reset();
    }
}
