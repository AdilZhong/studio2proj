using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class door1 : MonoBehaviour
{
    public CanvasGroup uiText; // ����UI�ı�����
    private bool playerEnteredTrigger = false;

    public PlayableDirector timeline; // Timeline ����
    private void Start()
    {
        uiText.alpha = 0f;
        timeline.Stop();
    }

    void Update()
    {
        // �������ڴ��������ڲ��Ұ����� E ��
        if (playerEnteredTrigger && Input.GetKeyDown(KeyCode.E))
        {
            // ���� Timeline
            if (timeline != null)
            {
                timeline.Play();
            
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ����Ƿ���Player�����˴�����
        if (collision.CompareTag("Player"))
        {
            uiText.alpha = 1f;
            playerEnteredTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiText.alpha = 0f;
            playerEnteredTrigger |= false;
        }
    }
    public bool PlayerEnteredTrigger()
    {
        return playerEnteredTrigger;
    }
    public void OnTimelineFinished()
    {
        uiText.alpha = 0f;
        // ������һ������
        SceneLoadManager.Instance.LoadNextScene();
    }

}
