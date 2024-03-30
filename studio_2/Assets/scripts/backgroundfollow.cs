using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundfollow : MonoBehaviour
{
    public Transform target; // ��ҵ�Transform
    public float rotationSpeed = 1.0f; // ��ת�ٶ�
    public Vector3 offset; // ��������֮���ƫ����
    public float delayTime = 10.0f; // �ӳٿ�ʼ��ת��ʱ��

    private float timer = 0.0f;
    private bool canRotate = false;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delayTime)
        {
            canRotate = true;
        }
    }
    void LateUpdate()
    {
        if (target != null)
        {
            
            // �������
            transform.position = target.position + offset;

            if (canRotate)
            {
                // ������ʱ����ת
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
