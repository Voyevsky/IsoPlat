﻿using System.Collections;
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
    [SerializeField]private float attackCooldown = 0.33f;
    private float attackTimePassed = 0.0f;
    public bool alive = true;

    public Rigidbody mrBatRB;

    private Animator mrBatAnim;
    private Collider col;
    private Vector3 startingPosition;

    private int playerInteractionState = 1; // 1 - go to starting position, 2 - follow player, 3 - stop and shoot

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
            if (playerInteractionState == 1)
            {
                GoTowardsPoint(startingPosition);
                //Debug.Log("ass");
            }

            if (playerInteractionState == 2)
            {
                GoTowardsPoint(player.transform.position);
            }

            if (playerInteractionState == 3)
            {
                Shoot();
            }

            attackTimePassed -= Time.deltaTime;
               
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

    void ChangeState(int newState)
    {
        playerInteractionState = newState;
    }

    void Shoot()
    {
        if(attackTimePassed <= 0.0f)
        {
            /*
            -create a boolet
            -get a vector between bat and player
            -use vector as direction
            */
            Debug.Log("Pow!");
            attackTimePassed = attackCooldown;
        }
    }

    void GoTowardsPoint(Vector3 point)
    {
        mrBatRB.AddForce((point - transform.position).normalized * movementSpeed);
    }

    void Death()
    {
        col.enabled = false;
        alive = false;
        Invoke("RemoveEvidence", 5);
    }

    void FakeFriction()
    {
        Vector3 fakeFriction = mrBatRB.velocity;
        fakeFriction.y = 0.0f;
        fakeFriction.z *= 0.9f;
        fakeFriction.x *= 0.9f;

        mrBatRB.velocity = fakeFriction;
    }

    void RemoveEvidence()
    {
        Destroy(gameObject);
    }

    #endregion
}
