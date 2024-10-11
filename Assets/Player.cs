using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform player; // 플레이어의 위치를 추적하기 위한 변수
    public Transform[] enemies; // 적의 위치를 추적하기 위한 배열
    public float detectionRange = 10f; // 적이 플레이어를 감지하는 범위

    // 심장박동 소리 클립
    public AudioSource audioSource; // 오디오 소스

    private bool isNearby = false; // 적이 플레이어 근처에 있는지 여부

    void Start()
    {
        
        player = GetComponent<Transform>();
    }

    void Update()
    {
        // 모든 적 오브젝트에 대해 처리
        foreach (Transform enemy in enemies)
        {
            // 플레이어와 적의 거리 계산
            float distanceToPlayer = Vector3.Distance(player.position, enemy.position);

            // 플레이어와 적의 거리가 감지 범위 이내이면
            if (distanceToPlayer <= detectionRange)
            {
                isNearby = true;
                break; // 하나라도 근처에 있으면 더 이상 검사할 필요 없음
            }
            else
            {
                isNearby = false;
            }
        }

        // 적이 플레이어 근처에 있고, 아직 소리를 재생하지 않은 경우
        if (isNearby )
        {
            // 심장박동 소리 재생
            audioSource.mute = false;
        }
        // 적이 플레이어 근처에 없는 경우 또는 이미 소리를 재생 중인 경우
        else if (!isNearby )
        {
            // 소리 중지
            audioSource.mute = true;
        }
    }
}

