using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    private Vector3 targetPosition;

    private Rigidbody2D platform_rb;

    private void Start() {
        platform_rb = GetComponent<Rigidbody2D>();
        targetPosition = pointB.position;
    }

    private void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.5f) {
            if (targetPosition == pointA.position) {
                targetPosition = pointB.position;
            }
            else {
                targetPosition = pointA.position;
            }
        }
    }
}
