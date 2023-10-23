using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetTransform : MonoBehaviour
{
    public struct ResetPuzzel
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
    }

    private List<ResetPuzzel> historyOfArrangement;

    private void Start()
    {
        historyOfArrangement = new List<ResetPuzzel>();

        StartCoroutine(InputMoveCoroutine());
    }

    IEnumerator InputMoveCoroutine()
    {
        while(true)
        {
            yield return null;
            
            //if(Input.GetKey(Mouse)
        }
    }

    // public void Reset()
    //{
    //    SceneManager.LoadScene("SampleScene");
    //}
}