using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonLogic : MonoBehaviour
{
    public event Action<bool> OnButtonPressed; // ���尴ť�����¼�

    public void ButtonPressed(bool isYesButton)
    {
        OnButtonPressed?.Invoke(isYesButton); // ������ť�����¼��������ݰ�ť���ͣ�trueΪyes��falseΪno��
    }
}
