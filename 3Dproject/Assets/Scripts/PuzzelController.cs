using UnityEngine;

public class PuzzelController : MonoBehaviour
{
    private Quaternion[] initialRotations;

    void Start()
    {
        initialRotations = new Quaternion[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            initialRotations[i] = transform.GetChild(i).localRotation;
        }
    }

    public void ResetPuzzle()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).localRotation = initialRotations[i];
        }
    }
}