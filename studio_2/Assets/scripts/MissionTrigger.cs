using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
public class MissionTrigger : MonoBehaviour
{
    public CanvasGroup checkText;
    public List<CanvasGroup> canvasGroups = new List<CanvasGroup>();
    private bool isInRange = false;

    void Start()
    {
        checkText.alpha = 0f;
        foreach (CanvasGroup canvasGroup in canvasGroups)
        {
            canvasGroup.alpha = 0f;

        }
    }
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(DisplayTextSequence());
        }
    }

    IEnumerator DisplayTextSequence()
    {
        // ���ؼ���ı�
        checkText.alpha = 0f;

        // �����ʾ�ı�
        foreach (CanvasGroup canvasGroup in canvasGroups)
        {
            canvasGroup.alpha = 1f;
            yield return new WaitForSeconds(3f); // �ȴ���ʱ��
            canvasGroup.alpha = 0f;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            // ��ʾ����ı�
            checkText.alpha = 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            // ���ؼ���ı�
            checkText.alpha = 0f;
        }
    }
}
