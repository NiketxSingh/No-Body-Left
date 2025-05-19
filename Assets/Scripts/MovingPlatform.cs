using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    private float destination_x;
    private float direction_x;

    private Rigidbody2D platform_rb;

    private void Start() {
        platform_rb = GetComponent<Rigidbody2D>();
        destination_x = pointB.position.x;
    }

    private void FixedUpdate() {
        direction_x = Mathf.Sign(destination_x - transform.position.x);
        platform_rb.velocity = new Vector2(direction_x * moveSpeed, 0f);

        if(Mathf.Abs(destination_x - transform.position.x) < 0.05 && destination_x>0) {
            destination_x = pointA.position.x;
        }
        else if (Mathf.Abs(destination_x - transform.position.x) < 0.05 && destination_x <0) {
            destination_x = pointB.position.x;
        }
    }
}
