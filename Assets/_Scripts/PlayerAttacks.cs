using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{

    public Collider basicAttackHitbox;

    public float basicMeleeDamage;
    public float attackTime = 0.2f;
    public float attackCooldown = 0.3f;

    private bool isAttacking = false;

    void Start()
    {
        basicAttackHitbox.enabled = false;
    }

    void Update()
    {
        if(Input.GetButtonDown("Attack") && !isAttacking)
        {
            Debug.Log("Attack!");
            basicAttackHitbox.enabled = true;
            isAttacking = true;
        }
    }
	
}
