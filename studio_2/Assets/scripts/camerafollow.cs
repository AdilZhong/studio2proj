using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target; // ��ҵ�Transform
    public Vector2 offset; // ��������֮���ƫ����
    public Vector2 minPosition; // ����ƶ�����Сλ��
    public Vector2 maxPosition; // ����ƶ������λ��

    void LateUpdate()
    {
        if (target != null)
        {
            // ���������Ŀ��λ��
            Vector3 targetPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

            // ��������ƶ���Χ
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            // �ƶ����
            transform.position = targetPosition;
        }
    }
}
