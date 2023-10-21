using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTransform : MonoBehaviour
{
    private float moveSpeed = 3.0f;
    private Vector3 moveDirection;

    private void Awake()
    {
        moveSpeed = 5.0f;
        moveDirection = Vector3.right;
    }

    //private void Awake()
    //{
    //    // �̵�/ȸ��/ũ�⸦ �����ϴ� "Transform" ������Ʈ�� ������ ������Ʈ �̵�
    //    // ���ο� ��ġ = ���� ��ġ + (���� * �ӵ�)
    //    // 1. transform.position = transform.position + new Vector3(1, 0, 0) * 1;
    //    // 2. A = A + B�� A += B�� ���� ����
    //    //    transform.position += new Vector3(1, 0, 0) * 1;
    //    // 3. 1 ������ ������ ��Ÿ�� ����
    //    //    new Vector3(1, 0, 0) ��� ����Ƽ���� �����ϴ� Vector3.right�� ���� ���
    //    transform.position += Vector3.right * 1;
    //}

    private void Update()
    {
        // Left, aŰ�� ������ -1 / Right, dŰ�� ������ +1 / �ƹ� Ű�� ������ ������ 0
        float x = Input.GetAxisRaw("Horizontal");

        // Down, sŰ�� ������ -1 / Up, wŰ�� ������ +1 / �ƹ� Ű�� ������ ������ 0
        float z = Input.GetAxisRaw("Vertical");

        // �̵����� ����
        moveDirection = new Vector3(x, 0, z);

        //// �� �����Ӹ��� Update()�� ���۵� �� �̵������� (0, 0, 0)���� ����
        //moveDirection = Vector3.zero; // new Vector3(0, 0, 0)
        
        //// Up/Down/Left/Right ����Ű�� ������ �� �̵�����(moveDirection) ����
        //if(Input.GetKey(KeyCode.UpArrow))
        //{
        //    moveDirection += Vector3.forward;
        //}
        //else if(Input.GetKey(KeyCode.DownArrow))
        //{
        //    moveDirection += Vector3.back;
        //}
        //else if(Input.GetKey(KeyCode.LeftArrow))
        //{
        //    moveDirection += Vector3.left;
        //}
        //else if(Input.GetKey(KeyCode.RightArrow))
        //{
        //    moveDirection += Vector3.right;
        //}

        //transform.position += Vector3.right * 1 * Time.deltaTime;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
