using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    /// <summary>
    /// �ٸ� ������Ʈ�� �浹�ϴ� ���� 1ȸ ȣ��
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"{collision.gameObject.name} ������Ʈ�� �浹 ����");
    }

    /// <summary>
    /// �ٸ� ������Ʈ�� �浹�ϰ� �ִ� ���� �� ������ ȣ��
    /// </summary>
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log($"{collision.gameObject.name} ������Ʈ�� �浹 ��...");
    }

    /// <summary>
    /// �ٸ� ������Ʈ���� �浹�� ����Ǵ� ���� 1ȸ ȣ��
    /// </summary>
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log($"{collision.gameObject.name} ������Ʈ�� �浹 ����"); 
    } 
}