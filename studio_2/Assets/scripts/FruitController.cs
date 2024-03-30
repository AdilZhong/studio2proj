using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    void Start()
    {
        // ��ȡ����� Rigidbody2D ���
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // �޸�Ħ����
            rb.sharedMaterial.friction = 0.5f; // ����Ħ����Ϊ 0.5
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �����ײ���������
        if (collision.gameObject.CompareTag("Player"))
        {
            // ����ˮ������
            Destroy(gameObject);
        }
    }
}
