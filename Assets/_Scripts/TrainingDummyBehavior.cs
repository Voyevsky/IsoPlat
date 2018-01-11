using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummyBehavior : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Ouch!");
        if(currentHealth <=0)
        {
            Death();
        }
    }
	
    private void Death()
    {
        Debug.Log("Dead. Not big suprise.");
    }

}
