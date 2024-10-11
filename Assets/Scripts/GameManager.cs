using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] road;
    public GameObject cube;
    public GameObject item;
    public int itemNumber = 0;
    public bool haveItemScene;
    public bool haveItemSelf;
    public List<int> show;
    public GameObject key;
    public bool isOpen;

    public GameObject door;
    public Transform target; // 目标位置
    public float smoothSpeed = 5.0f; // 平滑速度
    private Vector3 velocity = Vector3.zero;

    public GameObject runUI;
    public ThirdPersonController thirdPersonController;
    [Range(586f, 960f)]
    public float run = 960f;
    public bool isRun;
    public float uiSpeed = 2f;


    public Transform[] enemyT;

    public Transform player;
    private void Awake()
    {
        instance = this;
        Debug.Log(runUI.transform.position);
    }

    private void Start()
    {
        while (show.Count < 5)
        {
            RandomNumber();
        }
        for (int i = 0; i < show.Count; i++)
        {
            Instantiate(cube, road[show[i]].transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }

        DesPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ReScene();



        if (Input.GetKeyDown(KeyCode.Escape))
            DesPanel();

        //if (!haveItemScene)
        //{
        //    int randomNumber = RandomWithoutDuplicates(show);
        //    Instantiate(item, road[randomNumber].transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        //    haveItemScene = true;
        //}
        //if (haveItemSelf)
        //{
        //    if (Input.GetKeyDown(KeyCode.R))
        //    {
        //        haveItemSelf = false;
        //        haveItemScene = false;
        //    }
        //}



    }

    public void RandomNumber()
    {
        int temp = Random.Range(0, road.Length);
        if (show.Count == 0)
        {
            show.Add(temp);
        }
        if (show.Count > 0)
        {
            for (int i = 0; i < show.Count; i++)
            {
                if (temp == show[i])
                {
                    return;
                }
            }
            show.Add(temp);
        }
    }


    int RandomWithoutDuplicates(List<int> list)
    {
        int randomNumber;

        do
        {
            randomNumber = Random.Range(0, road.Length); // 随机数范围要与list的索引对应
        } while (list.Contains(randomNumber)); // 如果随机数在list里面，则继续循环随机

        return randomNumber;
    }

    public void ShowKey()
    {
        key.SetActive(true);
        Invoke("OpenDoor", 2f);

    }
    public Animator anim;
    public Collider col;
    public void OpenDoor()
    {
        anim.SetBool("Open", true);
        col.enabled = false;
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Open);
    }


    public GameObject RetryBtn;
    public GameObject WinText;
    public GameObject DefText;
    public void Retry()
    {
        DefText.SetActive(true);
        RetryBtn.SetActive(true);
        Time.timeScale = 0;
    }

    public void Win()
    {
        WinText.SetActive(true);
        Time.timeScale = 0;
    }

    public GameObject panel;
    public void ReScene()
    {
        SceneManager.LoadScene(0);
    }
    bool isStop;
    public void DesPanel()
    {
        if(isStop)
        {
            panel.SetActive(false);
            Time.timeScale = 1;
            isStop = false;
        }
        else if(!isStop)
        {
            panel.SetActive(true);
            Time.timeScale = 0;
            isStop = true;
        }
        
    }
}
