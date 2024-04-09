using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager Instance;
    private door1 door1;

    private void Start()
    {
        door1 = FindObjectOfType<door1>();
    }

    // ����������ڳ�������ʱ���ã���ʼ����̬ʵ��
    private void Awake()
    {
        // ȷ��ֻ��һ��ʵ������
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // �����ö��󣬼�ʹ�������³���
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (door1.PlayerEnteredTrigger() && Input.GetKeyDown(KeyCode.E))
        {
            LoadNextScene();
        }
    }

    // ������һ�������ĺ���
    public void LoadNextScene()
    {
        // ��ȡ��ǰ����������
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ������һ�������������ǰ�����������һ������
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.LogWarning("��ǰ�����Ѿ������һ������");
        }
    }
}
