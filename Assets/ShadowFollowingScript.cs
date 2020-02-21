using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShadowFollowingScript : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target, home;

    private float distance;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        agent.speed = 4.5f;
        agent.acceleration = 32;
        distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < 20.0 && transform.position.z > -24.0f)
        {
            agent.SetDestination(target.transform.position);
        }
        else
        {
            agent.SetDestination(home.transform.position);
        }
    }
}
