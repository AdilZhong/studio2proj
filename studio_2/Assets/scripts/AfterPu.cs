using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterPu : MonoBehaviour
{
    public Transform landingPoint; // ���λ��

    // �ڶ����¼��е��õķ���
    public void MoveCharacterToLandingPoint()
    {
        if (landingPoint != null)
        {
            // �ƶ���ɫ�����λ��
            transform.position = landingPoint.position;
        }
        else
        {
            Debug.LogWarning("δ�������λ�ã�");
        }
    }
}
