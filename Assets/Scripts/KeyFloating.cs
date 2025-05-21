using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyFloating : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    private Vector3 targetPosition;
    [SerializeField] private float moveSpeed = 0.5f;

    private void Start() {
        targetPosition = pointA.position;
    }
    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.05f) {
            if (targetPosition == pointA.position) {
                targetPosition = pointB.position;
            }
            else {
                targetPosition = pointA.position;
            }
        }
    }
}
