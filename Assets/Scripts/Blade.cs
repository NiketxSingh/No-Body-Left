using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    [SerializeField] private float maxAngle = 60f;
    [SerializeField] private float minAngle = -60f;
    [SerializeField] private float rotationSpeed = 0.5f;
    private float targetAngle;
    private bool maxReached = true;

    private void Start() {
        targetAngle = maxAngle; 
    }

    private void Update() {
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.RotateTowards(currentRotation,targetRotation,rotationSpeed);

        float diff = Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle);
        if(Mathf.Abs(diff)< 1f) {
            targetAngle = maxReached? minAngle: maxAngle;
            maxReached = !maxReached;
        }
    }
}
