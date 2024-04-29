using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public CanvasGroup text1CanvasGroup;
    public CanvasGroup text2CanvasGroup;
    void Start()
    {
        text1CanvasGroup.alpha = 0f;
        text2CanvasGroup.alpha = 0f;
    }
    void Update()
    {
        // �������Ƿ������巢����ײ�����Ұ����� F ��
        if (Input.GetKeyDown(KeyCode.F) && IsMouseOverObject())
        {
            SceneLoadManager.Instance.LoadNextNextScene();
        }
        if (Input.GetMouseButtonDown(0) && IsMouseOverObject())
        {
            SceneLoadManager.Instance.LoadNextScene();
        }
    }
    void OnMouseEnter()
    {
        if (gameObject.CompareTag("circle"))
        {
            
            text1CanvasGroup.alpha = 1f; // ��ʾ����1
            text2CanvasGroup.alpha = 0f; // ��������2
            
        }


        if (gameObject.CompareTag("square"))
        {
            
            text1CanvasGroup.alpha = 0f; // ��������1
            text2CanvasGroup.alpha = 1f; // ��ʾ 
        }
    }
    void OnMouseExit()
    {
        // �������뿪��ײ����ʱ��������������
        text1CanvasGroup.alpha = 0f;
        text2CanvasGroup.alpha = 0f;
    }
 

    bool IsMouseOverObject()
    {
        // ��ȡ��굱ǰλ��
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // �������Ƿ�λ��������ײ����
        Collider2D collider = Physics2D.OverlapPoint(mousePosition);
        return collider != null && collider.gameObject == gameObject;
    }
}
    