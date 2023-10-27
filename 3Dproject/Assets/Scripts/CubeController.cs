using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeController : MonoBehaviour
{
    [SerializeField]
    private MovementCharacterController movementCharacterController;
    private Vector3 setPuzzelRotation;
    float x;

    private void Start()
    {
        setPuzzelRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
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
                    Debug.Log(hit.transform.name);
                    x += 90;
                    hit.transform.gameObject.transform.localEulerAngles = new Vector3(x, 0, 0);
                }
            }
        }
    }

    public void Reset()
    {
        transform.eulerAngles = setPuzzelRotation;
    }
}
