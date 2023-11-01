using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target; // 카메라가 쫓아다니는 대상 (일반적으로 플레이어)

    private float distance; // 목표와의 거리

    private float xAxisSpeed = 400.0f; // x축 회전 속도
    private float yAxisSpeed = 1000.0f; // y축 회전 속도
    private float xAxisLimitMin = 5.0f; // 회전 가능한 x축 최소 각도
    private float xAxisLimitMax = 80.0f; // 회전 가능한 x축 최대 각도
    private float x, y;

    private float zoomDistance = 2.0f;

    private void Awake()
    {
        // 카메라의 위치 = 플레이어의 위치에서 카메라의 전방 방향을 기준으로 뒤로 zoomDistance만큼 떨어진 거리
        transform.position = target.position + transform.rotation * Vector3.back * zoomDistance;
    }

    private void Update()
    {
        // 마우스 오른쪽 버튼을 누르고 있을 때만 카메라 회전
        if(Input.GetMouseButton(1))
        {
            UpdateRotate();
        }
    }

    private void LateUpdate()
    {
        // 쫓아다닐 대상이 없으면 return
        if (!target) return;

        // 카메라의 위치 = 플레이어의 위치에서 카메라의 전방 방향을 기준으로 뒤로 zoomDistance만큼 떨어진 거리
        transform.position = target.position + transform.rotation * Vector3.back * zoomDistance;
    }

    private void UpdateRotate()
    {
        // 마우스의 y축 위치 변화를 바탕으로 카메라의 x축 회전 값 설정
        x -= Input.GetAxisRaw("Mouse Y") * xAxisSpeed * Time.deltaTime;
        // 마우스의 x축 위치 변화를 바탕으로 카메라의 y축 회전 값 설정
        y += Input.GetAxisRaw("Mouse X") * yAxisSpeed * Time.deltaTime;

        // 카메라의 x축 회전은 min ~ max 사이로만 가능하도록 설정
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
