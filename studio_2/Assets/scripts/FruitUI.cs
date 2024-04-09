using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitUI : MonoBehaviour
{
    public Text fruitCountText; // ����UI�ı�����
    private int fruitCount = -1;
    private int targetFruitCount = 50; // Ŀ��ˮ������

    private void Start()
    {
        
        FruitController.OnFruitEaten += UpdateFruitCountText; // ����ˮ�����Ե����¼�
        UpdateFruitCountText(); // ��ʼ�� UI �ı���ʾ
    }

    private void UpdateFruitCountText()
    {
        fruitCount++;
        fruitCountText.text = fruitCount + "/" + targetFruitCount; // ����UI�ı���ʾ
    }

    private void OnDestroy()
    {
        FruitController.OnFruitEaten -= UpdateFruitCountText; // ȡ������ˮ�����Ե����¼�
    }
}
