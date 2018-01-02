using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyBars : MonoBehaviour
{
    public float startingEnergy = 100;
    public float currentEnergy;
    public float regenerationRate = 0.5f;
    private float energyPercent;

    public float startingHealth = 100;
    public float currentHealth;
    private float healthPercent;

    public Slider energyBar;
    public Slider healthBar;

    void Start()
    {
        currentEnergy = startingEnergy;
        energyBar.value = 1.0f;

        currentHealth = startingHealth;
        healthBar.value = 1.0f;
    }
	
    void Update()
    {
        energyBar.value = energyPercent;
        healthBar.value = healthPercent;
    }

    void FixedUpdate()
    {
        //regenerating energy
        if(currentEnergy < startingEnergy)
        {
            currentEnergy += regenerationRate;
        }
        energyPercent = currentEnergy / startingEnergy;

        healthPercent = currentHealth / startingHealth;
        
    }

}
