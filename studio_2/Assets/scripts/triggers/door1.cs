using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class door1 : MonoBehaviour
{
    public CanvasGroup uiText; // ����UI�ı�����
    private bool playerEnteredTrigger = false;
    private void Start()
    {
        uiText.alpha = 0f;
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

        }
    }
    public bool PlayerEnteredTrigger()
    {
        return playerEnteredTrigger;
    }

}
