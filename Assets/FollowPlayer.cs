using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public GameObject player;
    public Vector3 offset;
    private float scrollValue = 15;
    private Vector3 desiredPos = new Vector3();
    void Start()
    {
        desiredPos = transform.position - player.transform.position;
    }

    float Ease(float value, float easeTo, float multiplier) {
        return value + (value < easeTo ? Mathf.Abs(value - easeTo) / multiplier : -Mathf.Abs(value - easeTo) / multiplier);
    }

    void Update() {
        scrollValue = Mathf.Clamp(scrollValue - Input.mouseScrollDelta.y * 2, 15, 50);
        offset.y = scrollValue;
        offset.z = -scrollValue;
        Vector3 to = player.transform.position + offset;
        Vector3 tempPos = transform.position;
        tempPos.x = Ease(tempPos.x, to.x, 15);
        tempPos.y = Ease(tempPos.y, to.y, 15);
        tempPos.z = Ease(tempPos.z, to.z, 15);

        transform.position = tempPos;


      // Quaternion turn = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2.0f, Vector3.up);
      // desiredPos = turn * desiredPos;
      // Vector3 newPos = player.transform.position + desiredPos;
      // transform.position = Vector3.Slerp(transform.position, newPos, 1.0f);
      // transform.LookAt(player.transform.position);


    }
}
