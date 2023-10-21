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
                // IsPointerOverGameObject() -> UI 클릭한 경우 true, 클릭하지 않은 경우 false
                // UI를 클릭하지 않았을 경우에만 오브젝트 회전
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
