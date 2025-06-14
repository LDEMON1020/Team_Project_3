using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // �� ������Ʈ�� �� �̵� �� �ı����� ����
            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject); // �̹� �����ϸ� �ߺ� ������ ���� ���� ����
        }
    }
}
