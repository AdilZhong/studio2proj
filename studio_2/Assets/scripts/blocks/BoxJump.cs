using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxJump : MonoBehaviour
{
    public float jumpForce = 10f; // ��Ծ����
    public Transform groundCheck; // ���ڼ�������������
    public LayerMask groundLayer; // �������ڵ�ͼ��

    private bool isGrounded; // �Ƿ��ڵ�����
    private Quaternion initialRotation; // ��ʼ��ת�Ƕ�

    void Start()
    {
        initialRotation = transform.rotation; // ��¼��ʼ��ת�Ƕ�
    }
    void Update()
    {
        transform.rotation = initialRotation;
        // ���ո���Ƿ񱻰���
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            
            Jump();
        }
    }
    void FixedUpdate()
    {
        // ����Ƿ��ڵ�����
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    void Jump()
    {
       
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);

    }
}
