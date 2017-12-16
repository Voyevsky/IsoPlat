using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    public bool grounded;

    public float movementSpeed;
    public float jumpForce;
    public float maxSpeed;
    public float dashSpeed;

    private Vector3 direction = new Vector3(0f, 0f, 0f);
    private bool isMoving = false;

	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
    {

        //Fake friction
        Vector3 fakeFriction = rb.velocity;
        fakeFriction.y = rb.velocity.y;
        fakeFriction.z *= 0.5f;
        fakeFriction.x *= 0.5f;

        rb.velocity = fakeFriction;

        //Basic movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        movement = Quaternion.AngleAxis(-135, Vector3.up) * movement;

        
        //Constant input
        if(movement.magnitude > 0)
        {
            isMoving = true;
            movement = movement.normalized;
        }
        else
        {
            isMoving = false;
        }

        direction = movement.normalized;

        rb.AddForce(movement * movementSpeed);
        
    }

    void Update()
    {
        //Dashing

        if (Input.GetButtonDown("Dash") && isMoving)
        {
            rb.AddForce(direction * dashSpeed);
            Debug.Log("Dash!");
        }
        
        //Jumping
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(0, jumpForce, 0);
            //grounded = false;
            Debug.Log("Jump!");
        }
    }
}
