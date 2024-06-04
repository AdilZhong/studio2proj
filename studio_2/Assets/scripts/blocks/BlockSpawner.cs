using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    private Vector3 lastBlockPosition; // ��һ�� block ��λ��
    public Vector3 initialPosition;

    void Start()
    {
        // ���� QTE ���������¼�
        qteDestory.OnQTEDestroyed += SpawnBlock;
        lastBlockPosition = initialPosition;
    }

    void SpawnBlock()
    {
        int randomIndex = Random.Range(0, blockPrefabs.Length); // ���ѡ��һ��Ԥ����
        GameObject selectedPrefab = blockPrefabs[randomIndex];

        Vector3 newPosition = lastBlockPosition + Vector3.up * 2f;

        // ���� block
        Instantiate(selectedPrefab, newPosition, Quaternion.identity);

        // ������һ�� block ��λ��Ϊ��ǰ���ɵ� block ��λ��
        lastBlockPosition = newPosition;
    }

    void OnDestroy()
    {
        // ȡ������ QTE ���������¼��������ڴ�й©
        qteDestory.OnQTEDestroyed -= SpawnBlock;
    }
}
