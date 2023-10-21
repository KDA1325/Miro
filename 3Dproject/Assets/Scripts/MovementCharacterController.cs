using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MovementCharacterController : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 2.0f; // �ȱ� �ӵ�
    [SerializeField]
    private float moveSpeed = 5.0f; // �̵� �ӵ�
    private Vector3 moveDirection = Vector3.zero; // �̵� ����
    private Animator animator;

    [SerializeField]
    private Transform backViewCamera;
    private CharacterController characterController;
    
    public bool isTopView;
    //public bool isBackView;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (isTopView == false)
        {
            // Ű �Է����� x, z�� �̵� ���� ����
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            float offset = 1.0f;

            animator.SetFloat("horizontal", x * offset);
            animator.SetFloat("vertical", z * offset);

            moveSpeed = walkSpeed;

            // ������Ʈ�� �̵� ���� ����
            // moveDirection = new Vector3(x, moveDirection.y, z);
            Vector3 dir = backViewCamera.rotation * new Vector3(x, 0, z);
            moveDirection = new Vector3(dir.x, moveDirection.y, dir.z);

            // CharacterController�� ���ǵǾ� �ִ� Move() �޼ҵ带 �̿��� �̵�
            // �Ű������� ������ �� �̵� �Ÿ� ���� ���� (�̵� ���� * �̵� �ӵ� * Time.deltaTime)
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

            // ���� ī�޶� �ٶ󺸰� �ִ� ���� ������ ������ ����
            transform.rotation = Quaternion.Euler(0, backViewCamera.eulerAngles.y, 0);
        }
        else
        {
            // Ű �Է����� x, z�� �̵� ���� ����
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            float offset = 0.0f;

            animator.SetFloat("horizontal", x * offset);
            animator.SetFloat("vertical", z * offset);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log($"{hit.gameObject.name} ������Ʈ�� �浹");
    }
}
