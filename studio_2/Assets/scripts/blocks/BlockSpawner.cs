using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    private Vector3 lastBlockPosition; // ��һ�� block ��λ��

    void Start()
    {
        // ���� QTE ���������¼�
        qteDestory.OnQTEDestroyed += SpawnBlock;
        lastBlockPosition = blockPrefab.transform.position;
    }

    void SpawnBlock()
    {
        Vector3 newPosition = lastBlockPosition + Vector3.up * 2f;

        // ���� block
        Instantiate(blockPrefab, newPosition, Quaternion.identity);


        // ������һ�� block ��λ��Ϊ��ǰ���ɵ� block ��λ��
        lastBlockPosition = newPosition;
    }

    void OnDestroy()
    {
        // ȡ������ QTE ���������¼��������ڴ�й©
        qteDestory.OnQTEDestroyed -= SpawnBlock;
    }
}
