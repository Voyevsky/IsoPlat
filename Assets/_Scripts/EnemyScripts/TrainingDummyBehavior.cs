using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummyBehavior : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;

    public bool alive = true;
    private Animator dummyAnim;

    private Collider dummyCol;
    private Rigidbody dummyRB;

    void Start()
    {
        currentHealth = maxHealth;
        dummyAnim = gameObject.GetComponentInChildren<Animator>();
        dummyCol = gameObject.GetComponent<Collider>();
        dummyRB = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        dummyAnim.SetBool("isAlive", alive);
    }
    public void TakeDamage(float damage)
    {

        if (alive)
        {
            currentHealth -= damage;
            Debug.Log("Ouch!");
            if (currentHealth <= 0)
            {
                Death();
            }
        }
        
    }
	
    private void Death()
    {
        Debug.Log("Dead. Not big suprise.");
        alive = false;
        dummyCol.enabled = false;
        dummyRB.isKinematic = true;
    }

}
