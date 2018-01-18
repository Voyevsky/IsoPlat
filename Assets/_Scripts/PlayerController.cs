using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private TrailRenderer trail;

    public bool grounded;

    public float movementSpeed;
    public float jumpForce;
    public float maxSpeed;
    public float dashSpeed;


    public Vector3 direction = new Vector3(1f, 0f, 1f);
    private bool isMoving = false;
    [SerializeField] private GameObject characterSprite;
    private Animator playerAnim;

    private bool isLookingUp = false;
    //public Vector3 currentPosition;

	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        trail = gameObject.GetComponent<TrailRenderer>();
        playerAnim = gameObject.GetComponentInChildren<Animator>();
	}
	
	void FixedUpdate ()
    {

        FakeFriction(0.5f);

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

        SpriteDirection();

        //Dashing

        if (Input.GetButtonDown("Dash") && isMoving && gameObject.GetComponent<PlayerEnergyBars>().currentEnergy >= 50)
        {
            rb.AddForce(direction * dashSpeed);
            trail.enabled = true;

            Debug.Log("Dash!");
            gameObject.GetComponent<PlayerEnergyBars>().currentEnergy -= 50;

            Invoke("TrailFade", 0.15f);
        }
        
        //Jumping
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(0, jumpForce, 0);
            Debug.Log("Jump!");
        }
    }
    #region Movement functions
    void FakeFriction(float speedReduction)
    {
        Vector3 fakeFriction = rb.velocity;
        fakeFriction.y = rb.velocity.y;
        fakeFriction.z *= speedReduction;
        fakeFriction.x *= speedReduction;

        rb.velocity = fakeFriction;
    }
    #endregion

    #region Other functions
    void SpriteDirection()
    {
        //flipping the sprite

        if (Input.GetAxis("Horizontal") > 0)
        {
            characterSprite.transform.localScale = new Vector3(-1.5f, 1.5f, 1);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            characterSprite.transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }

        //using up-looking animations
        playerAnim.SetBool("isLookingUp", isLookingUp);

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            isLookingUp = true;
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            isLookingUp = false;
        }
    }
    void TrailFade()
    {
        trail.enabled = false;
    }
    #endregion
}
