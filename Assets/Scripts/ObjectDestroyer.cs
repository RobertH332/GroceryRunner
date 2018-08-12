using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    private Transform destroyPoint;

    private void Start() {
        destroyPoint = GameObject.FindGameObjectWithTag("Destroyer").transform;
    }

    private void Update() {
        if (transform.position.y < destroyPoint.position.y) {
            Destroy(gameObject);
        }
    }
}
