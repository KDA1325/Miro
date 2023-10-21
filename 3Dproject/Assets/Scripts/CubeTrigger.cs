using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeTrigger : MonoBehaviour
{
    [SerializeField]
    private MovementCharacterController movementCharacterController;
    //[SerializeField]
    //private Camera camera;
    float y;

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
                    Debug.Log(hit.transform.name);
                    y += 90;
                    hit.transform.gameObject.transform.localEulerAngles = new Vector3(0, y, 0);
                }
            }
        }
    }
}
