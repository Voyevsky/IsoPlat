using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrBatBehavior : MonoBehaviour
{
    // Z
    //:3
    // Z

    public float maxHealth = 30;
    private float currentHealth;
    public bool alive = true;

    public Rigidbody mrBatRB;


    void Start()
    {
        currentHealth = maxHealth;
    }
    void FixedUpdate()
    {

        FakeFriction();
        
    }

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

    void Death()
    {
        Debug.Log("Bat is kill. Not big soup rice.");
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
}
