using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour {
    private Material material;
    private NavMeshObstacle obstacle;
    void Start() {
        material = GetComponent<MeshRenderer>().material;
        obstacle = GetComponent<NavMeshObstacle>();
    }

    public void Activate() {
        Color color = material.color;
        color.a = 0.1f;
        material.color = color;
        obstacle.enabled = false;
        transform.position += new Vector3(0, 0.1f, 0);
    }

    public void DeActivate() {
        Color color = material.color;
        color.a = 1.0f;
        material.color = color;
        obstacle.enabled = true;
        transform.position -= new Vector3(0, 0.1f, 0);
    }
}
