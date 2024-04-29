using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qteGenerater : MonoBehaviour
{
    public GameObject qtePrefab; // QTE �����Ԥ����

    void Start()
    {
        // ��ʼһ��Э�̣���ʱ���� QTE ����
        StartCoroutine(GenerateQTECoroutine());
    }
    IEnumerator GenerateQTECoroutine()
    {
        while (true)
        {
            // �ȴ�2��
            yield return new WaitForSeconds(2f);

            // ���� QTE ����
            GenerateQTE();
        }
    }


    void GenerateQTE()
    {
        // ��ȡ��Ļ�Ŀ�Ⱥ͸߶�
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // ����Ļ��Χ�������������
        Vector3 randomPosition = new Vector3(Random.Range(0, screenWidth), Random.Range(0, screenHeight), 10f);

        // ���������ת��Ϊ��������
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(randomPosition);

        // ������������� QTE ����
        Instantiate(qtePrefab, worldPosition, Quaternion.identity);
    }
}
