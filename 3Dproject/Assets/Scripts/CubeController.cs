using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeController : MonoBehaviour
{
    [SerializeField]
    private MovementCharacterController movementCharacterController;

    private void Awake()
    {
        //Vector3 initRotation = transform.localEulerAngles;
    }

    private void OnMouseDown()
    {
        if(movementCharacterController.isTopView == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // IsPointerOverGameObject() -> UI Ŭ���� ��� true, Ŭ������ ���� ��� false
                // UI�� Ŭ������ �ʾ��� ��쿡�� ������Ʈ ȸ��
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Vector3 currentRotation = hit.transform.localEulerAngles;
                    currentRotation.z += 90;

                    hit.transform.localEulerAngles = currentRotation;
                }
            }
        }
    }
}
