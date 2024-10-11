using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform player; // �÷��̾��� ��ġ�� �����ϱ� ���� ����
    public Transform[] enemies; // ���� ��ġ�� �����ϱ� ���� �迭
    public float detectionRange = 10f; // ���� �÷��̾ �����ϴ� ����

    // ����ڵ� �Ҹ� Ŭ��
    public AudioSource audioSource; // ����� �ҽ�

    private bool isNearby = false; // ���� �÷��̾� ��ó�� �ִ��� ����

    void Start()
    {
        
        player = GetComponent<Transform>();
    }

    void Update()
    {
        // ��� �� ������Ʈ�� ���� ó��
        foreach (Transform enemy in enemies)
        {
            // �÷��̾�� ���� �Ÿ� ���
            float distanceToPlayer = Vector3.Distance(player.position, enemy.position);

            // �÷��̾�� ���� �Ÿ��� ���� ���� �̳��̸�
            if (distanceToPlayer <= detectionRange)
            {
                isNearby = true;
                break; // �ϳ��� ��ó�� ������ �� �̻� �˻��� �ʿ� ����
            }
            else
            {
                isNearby = false;
            }
        }

        // ���� �÷��̾� ��ó�� �ְ�, ���� �Ҹ��� ������� ���� ���
        if (isNearby )
        {
            // ����ڵ� �Ҹ� ���
            audioSource.mute = false;
        }
        // ���� �÷��̾� ��ó�� ���� ��� �Ǵ� �̹� �Ҹ��� ��� ���� ���
        else if (!isNearby )
        {
            // �Ҹ� ����
            audioSource.mute = true;
        }
    }
}

