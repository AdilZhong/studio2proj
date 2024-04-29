using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFunction : MonoBehaviour
{
    private bool isDragging = false; // ��־�Ƿ������϶�����
    private Vector3 offset; // �����λ�ú�����λ�õ�ƫ����
    public Transform rotationCenter; // ��ת����
    public float rotationSpeed = 50f; // ��ת�ٶ�

    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos(); // ����ƫ����
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 targetPos = GetMouseWorldPos() + offset; // ����Ŀ��λ��
            transform.position = targetPos; // ��������λ��
        }
        RotateAroundPoint();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void RotateAroundPoint()
    {
        if (rotationCenter != null)
        {
            Vector3 offset = transform.position - rotationCenter.position;
            Quaternion rotation = Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime);
            offset = rotation * offset;
            transform.position = rotationCenter.position + offset;
        }
    }
}
