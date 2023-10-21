using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody : MonoBehaviour
{
    private Rigidbody rigid;
    private float moveSpeed = 5.0f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Left, aŰ�� ������ -1 / Right, dŰ�� ������ +1 / �ƹ� Ű�� ������ ������ 0
        float x = Input.GetAxisRaw("Horizontal");

        // Down, sŰ�� ������ -1 / Up, wŰ�� ������ +1 / �ƹ� Ű�� ������ ������ 0
        float z = Input.GetAxisRaw("Vertical");

        // �ӷ� = �̵� ���� * �̵� �ӵ�
        rigid.velocity = new Vector3(x, 0, z) * moveSpeed;

        
    }

}
