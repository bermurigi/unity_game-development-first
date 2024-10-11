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
        // 메인 카메라 가져오기
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

        // 만약 건물에 가려진 경우
        if (isObstacleBetween)
        {
            
            return;
        }

        // 만약 Enemy 오브젝트가 카메라 시야 내에 있다면
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
