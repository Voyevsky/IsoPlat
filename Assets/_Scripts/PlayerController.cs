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
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
    {
        //Basic movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Debug.Log(horizontal);
        Debug.Log(vertical);

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        movement = Quaternion.AngleAxis(-135, Vector3.up) * movement;

        
        //Constant input
        if(movement.magnitude > 1f)
        {
            movement = movement.normalized;
        }
        
        //Speed limiting
        if(rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);
        }

        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, rb.velocity.z);
        }

        if (rb.velocity.z > maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
        }

        if (rb.velocity.z < -maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxSpeed);
        }

        Debug.Log("X axis: " + movement.x);
        Debug.Log("Z axis: " + movement.z);

        Debug.Log("Magnitude: " + movement.magnitude);

        rb.AddForce(movement * movementSpeed);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(0, jumpForce, 0);
        }

        
    }
}
