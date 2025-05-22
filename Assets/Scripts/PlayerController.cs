using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //Physics constants
    [SerializeField] private float speed_x = 5f;
    [SerializeField] private float g_ascent = -22f;
    [SerializeField] private float g_descent = -44f;
    //private Vector2 velocity = Vector2.zero;

    //Jump
    [SerializeField] private float jumpVelocity = 12f;
    [SerializeField] private float variableJumpMultiplier = 0.5f;
    [SerializeField] private float jumpBufferTime = 0.1f;
    private float jumpBufferCounter = 0;
    [SerializeField] private float coyoteTime = 0.1f;
    private float coyoteTimeCounter = 0;

    //Horizontal Input
    private float input_x;

    //Ground Check
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private LayerMask groundLayer;
    private float raycastCheckDistance = 0.15f;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator anim;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        isGrounded = groundCheck(); // check once per frame
        if (!isGrounded) {
            anim.SetBool("isJumping", true);
        }
        else {
            anim.SetBool("isJumping",false);
        }
        HorizontalMovement();
        Jump();
        ApplyGravity();
        //transform.position += new Vector3(velocity.x, velocity.y, 0f) * Time.deltaTime;
    }

    private bool groundCheck() {
        RaycastHit2D leftHit = Physics2D.Raycast(leftFoot.position, Vector2.down, raycastCheckDistance, groundLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(rightFoot.position, Vector2.down, raycastCheckDistance, groundLayer);

        return leftHit.collider != null || rightHit.collider != null;
    }

    private void ApplyGravity() {
        if (rb.velocity.y > 0) {
            // Player going up - use lighter gravity
            rb.velocity += Vector2.up * g_ascent * Time.deltaTime;
        }
        else if (rb.velocity.y < 0) {
            // Player falling down - heavier gravity
            rb.velocity += Vector2.up * g_descent * Time.deltaTime;
        }
    }

    private void HorizontalMovement() {
        input_x = Input.GetAxisRaw("Horizontal");

        if (input_x != 0) {
            anim.SetBool("isRunning", true);
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(input_x) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else {
            anim.SetBool("isRunning",false);
        }
            rb.velocity = new Vector2(input_x * speed_x, rb.velocity.y);
    }

    private void Jump() {
        //Jump Buffer
        if (Input.GetKeyDown(KeyCode.Space)) {
            jumpBufferCounter = jumpBufferTime;
        }
        else {
            jumpBufferCounter -= Time.deltaTime;
        }
        //Coyote Time
        if (isGrounded) {
            coyoteTimeCounter = coyoteTime;
        }
        else {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if ((coyoteTimeCounter > 0) && (jumpBufferCounter > 0)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            isGrounded = false;
            jumpBufferCounter = 0;
            coyoteTimeCounter = 0;
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            if (rb.velocity.y > 0) {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * variableJumpMultiplier);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("movingplatform")) {
            foreach (ContactPoint2D contact in collision.contacts) {
                if (contact.normal.y >= 0.9f && rb.velocity.y <= 0) {
                    transform.parent = collision.transform;
                    break;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("movingplatform")) {
            transform.parent = null;
        }
    }


}
