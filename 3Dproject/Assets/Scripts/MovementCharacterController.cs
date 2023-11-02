using System.Collections;
using UnityEngine;

public class MovementCharacterController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f; // 이동 속도
    private Vector3 moveDirection = Vector3.zero; // 이동 방향
    private Vector3 initialPosition = new Vector3(0, 0, 0);
    private Animator animator;

    [SerializeField]
    private GameObject ChestInfo;
    [SerializeField]
    private GameObject ChestInfo2;
    [SerializeField]
    private GameObject TrophyInfo;
   
    [SerializeField]
    private Transform backViewCamera;
    private CharacterController characterController;
    private SceneManagerEX sceneManager;
    private TimeController timeController;

    public bool isTopView;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        sceneManager = GetComponent<SceneManagerEX>(); 
        timeController = GameObject.FindObjectOfType<TimeController>();

        ChestInfo.SetActive(false);
        TrophyInfo.SetActive(false);
    }

    private void Update()
    {
        // BackView일 때
        if (isTopView == false)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            float offset = 1.0f;

            animator.SetFloat("horizontal", x * offset);
            animator.SetFloat("vertical", z * offset);

            Vector3 dir = backViewCamera.rotation * new Vector3(x, 0, z);
            moveDirection = new Vector3(dir.x, moveDirection.y, dir.z);

            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Euler(0, backViewCamera.eulerAngles.y, 0);

            if (ChestInfo.activeSelf == true || ChestInfo2.activeSelf == true || TrophyInfo.activeSelf == true)
            {
                UpdateKeyCheck();
            }
        }
        // TopView일 때
        else
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            float offset = 0.0f;

            animator.SetFloat("horizontal", x * offset);
            animator.SetFloat("vertical", z * offset);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Chest")
        {
            ChestInfo.SetActive(true);
        }
        else if (other.gameObject.name == "Chest2")
        {
            ChestInfo2.SetActive(true);
        }
        else if (other.gameObject.name == "Trophy")
        {
            TrophyInfo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Chest")
        {
            ChestInfo.SetActive(false);
        }
        else if (other.gameObject.name == "Chest2")
        {
            ChestInfo2.SetActive(false);
        }
        else if (other.gameObject.name == "Trophy")
        {
            TrophyInfo.SetActive(false);
        }
    }

  
    private void UpdateKeyCheck()
    {
        // 조건 분리하기
        if(ChestInfo.activeSelf == true || ChestInfo2.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChestChange();
            }
        }
        else if(TrophyInfo.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Clear");
                timeController.isEnded = true;
                sceneManager.EndGame();
            }
        }
    }
    private void ChestChange()
    {
        GameObject chest = GameObject.Find("Chest");
        GameObject closeChest = chest.transform.GetChild(1).gameObject;
        GameObject openChest = chest.transform.GetChild(2).gameObject;

        closeChest.SetActive(false);
        openChest.SetActive(true);

        StartCoroutine(MoveInitPos());
    }

    private IEnumerator MoveInitPos()
    {
        yield return new WaitForSeconds(0.5f); 
        
        characterController.enabled = false;
        transform.position = initialPosition;
        characterController.enabled = true;
    }
}
