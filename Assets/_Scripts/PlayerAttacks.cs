using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{

    public Collider basicAttackHitbox;
    public Collider specialAttackHitbox;

    public float attackCooldown = 0.33f;

    public float specialDamage = 50;

    private bool isAttacking = false;
    private bool isPerformingSpecial = false;
    private float attackTimePassed = 0f;

    private int spellId = 0;

    void Start()
    {
        basicAttackHitbox.enabled = false;
        specialAttackHitbox.enabled = false;
    }

    /*
        -getkey
        -if not attacking, activate hitbox
        -set isAttacking to true
        -activate hitbox
        -deactivate after one frame/some time has passed
        -after cooldown, set isAttacking to false
    */

    void Update()
    {
        Deactivate();

        if (Input.GetButtonDown("Attack") && !isAttacking)
        {
            Debug.Log("Attack!");
            NormalAttack();
        }

        if (Input.GetButtonDown("Special") && !isAttacking && gameObject.GetComponent<PlayerEnergyBars>().currentEnergy >= 70)
        {
            Debug.Log("Special Attack!");
            SpecialAttack();
        }

        if (isAttacking)
        {
            attackTimePassed += Time.deltaTime;

            if (attackTimePassed >= attackCooldown)
            {
                attackTimePassed = 0f;
                isAttacking = false;
            }
        }

        if (Input.GetButtonDown("Magic"))
        {

        }

    }

    void NormalAttack()
    {
        basicAttackHitbox.enabled = true;
        isAttacking = true;
    }

    void SpecialAttack()
    {
        specialAttackHitbox.enabled = true;
        isAttacking = true;
        gameObject.GetComponent<PlayerEnergyBars>().currentEnergy -= 70;
    }

    void Magic()
    {

    }
	
    void Deactivate()
    {
        if (basicAttackHitbox.enabled)
        {
            basicAttackHitbox.enabled = false;
        }
        if(specialAttackHitbox.enabled)
        {
            specialAttackHitbox.enabled = false;
        }
    }

}
