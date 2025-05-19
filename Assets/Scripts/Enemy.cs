using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    private Vector3 targetPosition;

    private Rigidbody2D enemy_rb;

    private void Start() {
        enemy_rb = GetComponent<Rigidbody2D>();
        targetPosition = pointB.position;
    }

    private void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.5f) {
            if(targetPosition == pointA.position) {
                targetPosition = pointB.position;
            }
            else {
                targetPosition = pointA.position;
            }

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void OnEnable() {
        PlayerDeath.OnBlast += ReceivedBlast;
    }

    private void OnDisable() {
        PlayerDeath.OnBlast -= ReceivedBlast;
    }

    private void ReceivedBlast(Vector2 blastPosition, float blastRadius) {
        float dist = Vector2.Distance(transform.position, blastPosition);
        Debug.Log(dist);
        if (dist < blastRadius) {
            Destroy(gameObject);
        }
    }
}
