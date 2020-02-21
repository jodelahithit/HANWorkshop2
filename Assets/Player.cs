using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour {
    private NavMeshAgent agent;
    public GameObject cross;
    public GameObject shadow;
    public GameObject shadow2;

    private List<LightAgentScript> lights = new List<LightAgentScript>();

    public void AddLight(LightAgentScript light) {
        lights.Add(light);
        light.ActivateDoor();
    }

    public void RemoveLight(LightAgentScript light) {
        lights.Remove(light);
        light.DeActivateDoor();
    }

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        if (agent.remainingDistance <= agent.stoppingDistance) {
            cross.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)) {
                //if (hit.transform.name == "Floor" || hit.transform.name == "Floor (1)") {
                    agent.destination = hit.point;
                    cross.SetActive(true);
                    cross.transform.position = hit.point + new Vector3(0, 0.2f, 0);
                //}
            }
        }

        if (Vector3.Distance(transform.position, shadow.transform.position) < 2.5f || Vector3.Distance(transform.position, shadow2.transform.position) < 2.5f) {
            print("dist");
            foreach (LightAgentScript l in lights) {
                l.DeActivateDoor();
            }
            lights.Clear();
        }
    }
}
