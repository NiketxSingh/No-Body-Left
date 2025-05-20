using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    [SerializeField] private GameObject mechanism;
    private bool onPlate = false;
    private float targetAngle;
    [SerializeField] private float openAngle = 0;
    [SerializeField] private float closeAngle= -90;
    [SerializeField] private float rotationSpeed = 0.5f;

    private void Start() {
        targetAngle = closeAngle;
    }

    private void Update() {
        Quaternion currentRotation = mechanism.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        mechanism.transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed);
        if (onPlate) {
            targetAngle = openAngle;
        }
        else {
            targetAngle = closeAngle;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("dead")) {
            onPlate = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("dead")) {
            onPlate = false;
        }
    }

}

