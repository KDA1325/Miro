using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetTransform : MonoBehaviour
{
    private Vector3 resetPuzzelRotation;

    private void Start()
    {
        resetPuzzelRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    }

    public void Reset()
    {
        transform.eulerAngles = resetPuzzelRotation;
    }

    //public struct ResetPuzzel
    //{
    //    //public Vector3 position;
    //    public Vector3 rotation;
    //    //public Vector3 scale;
    //}

    //private List<ResetPuzzel> historyOfTransform;


    //private void Start()
    //{
    //    ResetPuzzel init;
    //    historyOfTransform = new List<ResetPuzzel>();

    //    init.rotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    //    ////ResetPuzzel temp;
    //    //Transform insert = transform;
    //    ////temp.position = new Vector3(insert.position.x, insert.position.y, insert.position.z);
    //    //temp.rotation = new Vector3(insert.rotation.x, insert.rotation.y, insert.rotation.z);
    //    ////temp.scale = new Vector3(insert.localScale.x, insert.localScale.y, insert.localScale.z);

    //    //historyOfTransform.Add(temp);
    //}

    //public void Reset()
    //{
    //    ResetPuzzel _trans = historyOfTransform[0];
    //    //transform.position = _trans.position;
    //    transform.eulerAngles = _trans.rotation;
    //    //transform.localScale = _trans.scale;
    //}
}