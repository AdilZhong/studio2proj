using System.Collections;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruitPrefab; // ˮ��Ԥ����
    public Transform[] spawnPoints; // ����ˮ����λ������
    public float spawnInterval = 2f; // ����ˮ���ļ��ʱ�䷶Χ

    void Start()
    {
        // ��ʼ����ˮ��Э��
        StartCoroutine(SpawnFruitsCoroutine());
    }

    IEnumerator SpawnFruitsCoroutine()
    {
        while (true)
        {
            // ���ѡ������ˮ��������
            int numberOfFruits = Random.Range(1, spawnPoints.Length + 1);

            // ��������ɵ�����ˮ��
            for (int i = 0; i < numberOfFruits; i++)
            {
                // ���ѡ��һ�����ɵ�
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Transform randomSpawnPoint = spawnPoints[randomIndex];

                // ����ˮ�����������ʼ����
                GameObject fruit = Instantiate(fruitPrefab, randomSpawnPoint.position, Quaternion.identity);
                // ���ˮ���и����������������һЩ��ʼ�ٶȵ�����
                Rigidbody2D rb = fruit.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                }
            }

            // �ȴ�һ��ʱ������������һ��ˮ��
            yield return new WaitForSeconds(Random.Range(spawnInterval, spawnInterval * 2));
        }
    }
}
