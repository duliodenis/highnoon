using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator an;

    public float movementSpeed = 10f;
    public float jumpForce = 400f;
    public float maxVelocityX = 4f;

    private bool isGrounded;

	// Use this for initialization
	void Start () {
        // Get Components
        rb = GetComponent<RigidBody2D>();
        an = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // force to be applied
        var force = new Vector2(0f, 0f);

        // Get controls for horizontal movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Get current velocity of the rigidbody2D
        var absVelocityX = Mathf.Abs(rb.velocity.x);
        var absVelocityY = Mathf.Abs(rb.velocity.y);

        // Check if on ground
        if (absVelocityY == 0) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }

        // Set the X-force
        if (absVelocityX < maxVelocityX) {
            force.x = (movementSpeed * moveHorizontal);
        }

        // Jump if grounded and button pressed
        if (isGrounded == true && Input.GetButton("Jump")) {
            isGrounded = false;
            force.y = jumpForce;
            an.SetInteger("Animstate", 2);
        }

        // Apply force
        rb.AddForce(force);
	}
}
