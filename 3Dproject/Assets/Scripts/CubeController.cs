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
                // IsPointerOverGameObject() -> UI 클릭한 경우 true, 클릭하지 않은 경우 false
                // UI를 클릭하지 않았을 경우에만 오브젝트 회전
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
