using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    public Camera mainCamera;

    private Enemy Enemy;
    public int chID;

    public LayerMask obstacleLayer;
    
    void Start()
    {
        // ���� ī�޶� ��������
        mainCamera = Camera.main;
        Enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);


        switch (chID)
        {
          
            case 3:
                if (Input.GetKey(KeyCode.LeftShift))
                    Enemy.agent.speed = 14;
                else
                    Enemy.agent.speed = 0;
                break;
        }


        RaycastHit hit;
        bool isObstacleBetween = Physics.Linecast(mainCamera.transform.position, transform.position, out hit, obstacleLayer);

        // ���� �ǹ��� ������ ���
        if (isObstacleBetween)
        {
            
            return;
        }

        // ���� Enemy ������Ʈ�� ī�޶� �þ� ���� �ִٸ�
        if (screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1 && screenPoint.z > 0)
        {
            switch(chID)
            {
                case 1:
                    Enemy.agent.speed = 6;
                    break;
                case 2:
                    Enemy.agent.speed = 0;
                    break;
                case 3:
                    break;
            }
           
        }
        else
        {
            switch (chID)
            {
                case 1:
                    Enemy.agent.speed = 0;
                    break;
                case 2:
                    Enemy.agent.speed = 6;
                    break;
                case 3:
                    break;
            }
        }
    }
}
