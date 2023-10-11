using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // �ٸ� ������Ʈ�� �浹�ϴ� ���� 1ȸ ȣ��
    private void OnTriggerEnter(Collider other)
    {
        // ������Ʈ�� ������ ������ �������� ����
        meshRenderer.material.color = Random.ColorHSV();

        Debug.Log($"{other.name} ������Ʈ�� �浹 ����");
    }

    // �ٸ� ������Ʈ�� �浹�ϰ� �ִ� ���� �� ������ ȣ��
    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"{other.name} ������Ʈ�� �浹 ��...");
    }

    // �ٸ� ������Ʈ���� �浹�� ����Ǵ� ���� 1ȸ ȣ��
    private void OnTriggerExit(Collider other)
    {
        // ������Ʈ�� ������ �Ͼ������ ����
        meshRenderer.material.color = Color.white;

        Debug.Log($"{other.name} ������Ʈ�� �浹 ����");
    }
}
