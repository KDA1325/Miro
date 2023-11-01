using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target; // ī�޶� �Ѿƴٴϴ� ��� (�Ϲ������� �÷��̾�)

    private float distance; // ��ǥ���� �Ÿ�

    private float xAxisSpeed = 400.0f; // x�� ȸ�� �ӵ�
    private float yAxisSpeed = 1000.0f; // y�� ȸ�� �ӵ�
    private float xAxisLimitMin = 5.0f; // ȸ�� ������ x�� �ּ� ����
    private float xAxisLimitMax = 80.0f; // ȸ�� ������ x�� �ִ� ����
    private float x, y;

    private float zoomDistance = 2.0f;

    private void Awake()
    {
        // ī�޶��� ��ġ = �÷��̾��� ��ġ���� ī�޶��� ���� ������ �������� �ڷ� zoomDistance��ŭ ������ �Ÿ�
        transform.position = target.position + transform.rotation * Vector3.back * zoomDistance;
    }

    private void Update()
    {
        // ���콺 ������ ��ư�� ������ ���� ���� ī�޶� ȸ��
        if(Input.GetMouseButton(1))
        {
            UpdateRotate();
        }
    }

    private void LateUpdate()
    {
        // �Ѿƴٴ� ����� ������ return
        if (!target) return;

        // ī�޶��� ��ġ = �÷��̾��� ��ġ���� ī�޶��� ���� ������ �������� �ڷ� zoomDistance��ŭ ������ �Ÿ�
        transform.position = target.position + transform.rotation * Vector3.back * zoomDistance;
    }

    private void UpdateRotate()
    {
        // ���콺�� y�� ��ġ ��ȭ�� �������� ī�޶��� x�� ȸ�� �� ����
        x -= Input.GetAxisRaw("Mouse Y") * xAxisSpeed * Time.deltaTime;
        // ���콺�� x�� ��ġ ��ȭ�� �������� ī�޶��� y�� ȸ�� �� ����
        y += Input.GetAxisRaw("Mouse X") * yAxisSpeed * Time.deltaTime;

        // ī�޶��� x�� ȸ���� min ~ max ���̷θ� �����ϵ��� ����
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
