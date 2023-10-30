using UnityEngine;

public class PuzzelResetController : MonoBehaviour
{
    private GameObject[] puzzleObjects; // 퍼즐 오브젝트 배열
    private Quaternion[] init; // 각 오브젝트의 초기 위치 저장 배열

    void Start()
    {
        // 씬에서 모든 퍼즐 오브젝트를 찾아 배열에 저장
        puzzleObjects = GameObject.FindGameObjectsWithTag("Puzzel");

        // 초기 위치를 저장할 배열 초기화
        init = new Quaternion[puzzleObjects.Length];

        // 각 퍼즐 오브젝트의 초기 위치 저장
        for (int i = 0; i < puzzleObjects.Length; i++)
        {
            init[i] = puzzleObjects[i].transform.rotation;
        }
    }

    public void ResetPuzzle()
    {
        // 모든 퍼즐 오브젝트를 초기 위치로 이동
        for (int i = 0; i < puzzleObjects.Length; i++)
        {
            puzzleObjects[i].transform.rotation = init[i];
        }
    }
}