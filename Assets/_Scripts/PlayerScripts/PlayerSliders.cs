using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyBars : MonoBehaviour
{
    public float startingEnergy = 100;
    public float currentEnergy;
    public float energyRegenRate = 0.5f;
    private float energyPercent;

    public float startingHealth = 100;
    public float currentHealth;
    private float healthPercent;

    public float startingMana = 100;
    public float currentMana;
    public float manaRegenRate = 0.3f;
    private float manaPercent;

    public Slider energyBar;
    public Slider healthBar;
    public Slider manaBar;

    void Start()
    {
        currentEnergy = startingEnergy;
        energyBar.value = 1.0f;

        currentHealth = startingHealth;
        healthBar.value = 1.0f;

        currentMana = startingMana;
        manaBar.value = 1.0f;
    }
	
    void Update()
    {
        SlidersValueUpdate();
    }

    void FixedUpdate()
    {
        Regeneration();
        SlidersPercentage();
    }

    #region Functions

    void Regeneration()
    {
        if (currentEnergy < startingEnergy)
        {
            currentEnergy += energyRegenRate;
        }

        if(currentMana < startingMana)
        {
            currentMana += manaRegenRate;
        }
    }
    void SlidersPercentage()
    {
        energyPercent = currentEnergy / startingEnergy;
        healthPercent = currentHealth / startingHealth;
        manaPercent = currentMana / startingMana;
    }

    void SlidersValueUpdate()
    {
        energyBar.value = energyPercent;
        healthBar.value = healthPercent;
        manaBar.value = manaPercent;
    }
    #endregion

}
