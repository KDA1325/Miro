using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MovementCharacterController : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 2.0f; // 걷기 속도
    [SerializeField]
    private float moveSpeed = 5.0f; // 이동 속도
    private Vector3 moveDirection = Vector3.zero; // 이동 방향
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
            // 키 입력으로 x, z축 이동 방향 설정
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            float offset = 1.0f;

            animator.SetFloat("horizontal", x * offset);
            animator.SetFloat("vertical", z * offset);

            moveSpeed = walkSpeed;

            // 오브젝트의 이동 방향 설정
            // moveDirection = new Vector3(x, moveDirection.y, z);
            Vector3 dir = backViewCamera.rotation * new Vector3(x, 0, z);
            moveDirection = new Vector3(dir.x, moveDirection.y, dir.z);

            // CharacterController에 정의되어 있는 Move() 메소드를 이용해 이동
            // 매개변수에 프레임 당 이동 거리 정보 적용 (이동 방향 * 이동 속도 * Time.deltaTime)
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

            // 현재 카메라가 바라보고 있는 전방 방향을 보도록 설정
            transform.rotation = Quaternion.Euler(0, backViewCamera.eulerAngles.y, 0);
        }
        else
        {
            // 키 입력으로 x, z축 이동 방향 설정
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            float offset = 0.0f;

            animator.SetFloat("horizontal", x * offset);
            animator.SetFloat("vertical", z * offset);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log($"{hit.gameObject.name} 오브젝트와 충돌");
    }
}
