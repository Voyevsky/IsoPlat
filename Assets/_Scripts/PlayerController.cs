using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    public float movementSpeed;

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

        Debug.Log(movement.x);
        Debug.Log(movement.z);

        rb.AddForce(movement * movementSpeed);
    }
}
