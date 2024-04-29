using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blur : MonoBehaviour
{
    public Shader blurShader; // ģ��Ч���� Shader
    private Material blurMaterial; // ģ��Ч���Ĳ���
    private float blurStrength = 5.0f; // ��ʼģ��ǿ��
    private float blurTime = 0.0f; // ��ʼģ��ʱ�����
    private bool mouseClicked = false; // �����״̬
    public float timespeed = 0.05f;
    void Start()
    {
        // ����ģ��Ч���Ĳ���
        blurMaterial = new Material(blurShader);
    }

    void Update()
    {
        // ����ģ��ʱ�����Ϊ��ǰʱ��
        blurTime += timespeed * Time.deltaTime;

        // ����������Ƿ���
        if (Input.GetMouseButtonDown(0))
        {
            // �����ʱ���޸������״̬Ϊ��
            mouseClicked = true;
        }
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        qteDestory.OnQTEDestroyed += HandleQTEDestroyed;
        
        // ������ɫ������
        blurMaterial.SetFloat("_BlurStrength", blurStrength);
        blurMaterial.SetFloat("_BlurTime", blurTime);
        Graphics.Blit(src, dest, blurMaterial);
    }
    void HandleQTEDestroyed()
    {
        // ��Сģ��ǿ��
        blurTime -= 1.0f;
        blurTime = Mathf.Max(blurTime, 0.0f); // ȷ��ģ��ǿ�Ȳ�С��0
    }
}
