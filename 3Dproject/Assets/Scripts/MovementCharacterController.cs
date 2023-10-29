using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MovementCharacterController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f; // �̵� �ӵ�
    private Vector3 moveDirection = Vector3.zero; // �̵� ����
    private Animator animator;

    [SerializeField]
    private GameObject Info;
    [SerializeField]
    private Transform backViewCamera;
    private CharacterController characterController;
    
    public bool isTopView;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        Info.SetActive(false);
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

            // ������Ʈ�� �̵� ���� ����
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
        
        // Ʈ���� ���� ���߿� �߰�
        if(hit.gameObject.name == "Chest")
        {
            Info.SetActive(true);
        }
        else
        {
            Info.SetActive(false);
        }
    }
}
