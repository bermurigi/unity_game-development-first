using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    private void Start()
    {
        agent=GetComponent<NavMeshAgent>(); 
        anim=GetComponent<Animator>();
    }
    private void Update()
    {

        if (agent.speed > 8)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (agent.speed>1)
        {
            anim.SetBool("Walk",true);
        }
        else
        {
            anim.SetBool("Walk",false);
        }
        
        agent.SetDestination(GameManager.instance.player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            GameManager.instance.Retry();
    }
}
