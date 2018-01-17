using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummyBehavior : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;

    public bool alive = true;

    void Start()
    {
        currentHealth = maxHealth;
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
    }

}
