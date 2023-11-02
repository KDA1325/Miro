using System.Collections;
using UnityEngine;

public class MovementCharacterController : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip[] audioClipsWalk;
    [SerializeField]
    private AudioClip audioClipChest;
    [SerializeField]
    private AudioClip audioClipTrophy;

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

    private GameObject chest;
    private GameObject closeChest;
    private GameObject openChest;

    [SerializeField]
    private Transform backViewCamera;
    private CharacterController characterController;
    private TimeController timeController;
    private AudioSource audioSource;

    public bool isTopView;
    private bool isClear = false;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        timeController = GameObject.FindObjectOfType<TimeController>();
        audioSource = GetComponent<AudioSource>();

        ChestInfo.SetActive(false);
        TrophyInfo.SetActive(false);
    }

    private void Update()
    {
        if (isTopView == false && isClear == false)
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

            if (x != 0 || z != 0)
            {
                
                if (audioSource.isPlaying == false)
                {
                    int index = Random.Range(0, audioClipsWalk.Length);
                    audioSource.clip = audioClipsWalk[index];
                    audioSource.loop = true;
                    audioSource.Play();
                }
            }
            else
            {
                if (audioSource.isPlaying == true)
                {
                    audioSource.Stop();
                }
            }

            if (ChestInfo.activeSelf == true || ChestInfo2.activeSelf == true || TrophyInfo.activeSelf == true)
            {
                UpdateKeyCheck();
            }
        }
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
        if (ChestInfo.activeSelf == true || ChestInfo2.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChestChange();
            }
        }
        else if (TrophyInfo.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                audioSource.PlayOneShot(audioClipTrophy);
                timeController.GameClear();
                isClear = true;
            }
        }
    }
    private void ChestChange()
    {
        if (ChestInfo.activeSelf == true)
        {
            chest = GameObject.Find("Chest");
            closeChest = chest.transform.GetChild(1).gameObject;
            openChest = chest.transform.GetChild(2).gameObject;
        }
        else if (ChestInfo2.activeSelf == true)
        {
            chest = GameObject.Find("Chest2");
            closeChest = chest.transform.GetChild(1).gameObject;
            openChest = chest.transform.GetChild(2).gameObject;
        }

        closeChest.SetActive(false);
        openChest.SetActive(true);
        audioSource.PlayOneShot(audioClipChest);

        StartCoroutine(MoveInitPos());
    }

    private IEnumerator MoveInitPos()
    {
        yield return new WaitForSeconds(0.7f);

        characterController.enabled = false;
        transform.position = initialPosition;
        characterController.enabled = true;
    }
}
