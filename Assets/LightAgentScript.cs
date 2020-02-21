using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LightAgentScript : MonoBehaviour {

    NavMeshAgent agent;
    public Player player;
    public bool following = false;
    public GameObject home;
    private bool homing = false;
    public Door door;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.acceleration = 32.0f;
        agent.angularSpeed = 250;
        agent.speed = 10.0f;
        agent.stoppingDistance = Random.Range(2.8f, 3.2f);
    }

    void FixedUpdate() {
        if (homing && agent.remainingDistance <= agent.stoppingDistance) {
            homing = false;
        }
        if (!following && !homing && Vector3.Distance(player.transform.position, transform.position) < 5) {
            following = true;
            player.AddLight(this);
        }

        if (following) {
            agent.SetDestination(player.transform.position);
        }
    }

    public void ActivateDoor() {
        door.Activate();
    }

    public void DeActivateDoor() {
        door.DeActivate();
        agent.SetDestination(home.transform.position);
        following = false;
        homing = true;
    }
}
