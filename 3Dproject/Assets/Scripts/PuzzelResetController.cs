using UnityEngine;

public class PuzzelResetController : MonoBehaviour
{
    private GameObject[] puzzleObjects; // ���� ������Ʈ �迭
    private Quaternion[] init; // �� ������Ʈ�� �ʱ� ��ġ ���� �迭

    void Start()
    {
        // ������ ��� ���� ������Ʈ�� ã�� �迭�� ����
        puzzleObjects = GameObject.FindGameObjectsWithTag("Puzzel");

        // �ʱ� ��ġ�� ������ �迭 �ʱ�ȭ
        init = new Quaternion[puzzleObjects.Length];

        // �� ���� ������Ʈ�� �ʱ� ��ġ ����
        for (int i = 0; i < puzzleObjects.Length; i++)
        {
            init[i] = puzzleObjects[i].transform.rotation;
        }
    }

    public void ResetPuzzle()
    {
        // ��� ���� ������Ʈ�� �ʱ� ��ġ�� �̵�
        for (int i = 0; i < puzzleObjects.Length; i++)
        {
            puzzleObjects[i].transform.rotation = init[i];
        }
    }
}