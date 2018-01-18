using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrBatBehavior : MonoBehaviour
{
    // Z
    //:3
    // Z
    public GameObject sprite;
    public float maxHealth = 30.0f;
    public float movementSpeed = 100.0f;
    private float currentHealth;
    public bool alive = true;

    public Rigidbody mrBatRB;

    private Animator mrBatAnim;
    private Collider col;
    private Vector3 startingPosition;

    [SerializeField] private GameObject player;
    void Start()
    {
        currentHealth = maxHealth;
        mrBatAnim = gameObject.GetComponentInChildren<Animator>();
        col = GetComponent<Collider>();
        startingPosition = transform.position;
    }
    void FixedUpdate()
    {
        FakeFriction();

        if (alive)
        {
            GoTowardsPoint(player.transform.position);
        }
    }

    void Update()
    {
        mrBatAnim.SetBool("isAlive", alive);

        if(!alive)
        {
            sprite.transform.Rotate(0.0f, 0.0f, 10.0f);
            transform.Translate(Vector3.down * 2.5f * Time.deltaTime, Space.World);
        }

    }

    #region Functions
    void TakeDamage(float damage)
    {
        if (alive)
        {
            currentHealth -= damage;
            Debug.Log("Bat is hit!");
            if (currentHealth <= 0f)
            {
                Death();
            }
        }
    }

    void GoTowardsPoint(Vector3 point)
    {
        mrBatRB.AddForce((point - transform.position).normalized * movementSpeed);
    }

    void Death()
    {
        Debug.Log("Bat is kill. Not big soup rice.");
        col.enabled = false;
        alive = false;
    }

    void FakeFriction()
    {
        Vector3 fakeFriction = mrBatRB.velocity;
        fakeFriction.y = 0.0f;
        fakeFriction.z *= 0.9f;
        fakeFriction.x *= 0.9f;

        mrBatRB.velocity = fakeFriction;
    }

    #endregion
}
