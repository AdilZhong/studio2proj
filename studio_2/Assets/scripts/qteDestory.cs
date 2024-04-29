using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qteDestory : MonoBehaviour
{
    public delegate void QTEDestroyedAction();
    public static event QTEDestroyedAction OnQTEDestroyed;
    void OnMouseEnter()
    {
        // ����껬�� QTE ����ʱ������
        Destroy(gameObject);
    }
    void OnDestroy()
    {
        // �����屻����ʱ�����¼�
        OnQTEDestroyed?.Invoke();
    }
}
