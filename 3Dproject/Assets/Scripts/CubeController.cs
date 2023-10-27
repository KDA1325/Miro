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
                // IsPointerOverGameObject() -> UI 클릭한 경우 true, 클릭하지 않은 경우 false
                // UI를 클릭하지 않았을 경우에만 오브젝트 회전
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
