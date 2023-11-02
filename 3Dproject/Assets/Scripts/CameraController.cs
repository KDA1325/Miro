using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target; 

    private float xAxisSpeed = 400.0f;
    private float yAxisSpeed = 1000.0f; 
    private float xAxisLimitMin = 5.0f; 
    private float xAxisLimitMax = 80.0f; 
    private float x, y;

    private float zoomDistance = 2.0f;

    private void Awake()
    {
        transform.position = target.position + transform.rotation * Vector3.back * zoomDistance;
    }

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            UpdateRotate();
        }
    }

    private void LateUpdate()
    {
        if (!target) return;

        transform.position = target.position + transform.rotation * Vector3.back * zoomDistance;
    }

    private void UpdateRotate()
    {
        x -= Input.GetAxisRaw("Mouse Y") * xAxisSpeed * Time.deltaTime;

        y += Input.GetAxisRaw("Mouse X") * yAxisSpeed * Time.deltaTime;

        x = ClampAngle(x, xAxisLimitMin, xAxisLimitMax);

        transform.rotation = Quaternion.Euler(x, y, 0);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
