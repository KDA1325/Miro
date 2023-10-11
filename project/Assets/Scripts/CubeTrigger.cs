using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrigger : MonoBehaviour
{
    float y;
    
    private void Awake()
    {
       
    }

    private void OnMouseDown()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.name);
            y += 90;
            hit.transform.gameObject.transform.localEulerAngles = new Vector3(0, y, 0);
        }
    }
}
