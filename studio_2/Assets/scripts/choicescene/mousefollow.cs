using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousefollow : MonoBehaviour
{
    void Update()
    {
        // ��ȡ��굱ǰλ��
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ���� z �᲻��
        mousePosition.z = 0f;
        // ������λ������Ϊ���λ��
        transform.position = mousePosition;
    }
}
