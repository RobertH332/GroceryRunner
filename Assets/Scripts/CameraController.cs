using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private PlayerController pc;
    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    private void Start() {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        lastPlayerPosition = pc.transform.position;
    }

    private void Update() {
        distanceToMove = pc.transform.position.y - lastPlayerPosition.y;
        transform.position = new Vector3(transform.position.x, transform.position.y + distanceToMove, transform.position.z);
        lastPlayerPosition = pc.transform.position;
    }
}
