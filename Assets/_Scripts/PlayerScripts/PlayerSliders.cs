using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField] private GameObject UIDeathScreen;
    [SerializeField] private string levelToLoad;

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
        Death();
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
    void Death()
    {
        if (currentHealth <= 0 && PlayerController.isAlive)
        {
            PlayerController.isAlive = false;
            Debug.Log("You are dead. Not big suprise.");
            Invoke("DeathScreen", 1.5f);
        }
    }
    void DeathScreen()
    {
        UIDeathScreen.SetActive(true);
        Invoke("LoadMenu", 3);
    }
    void LoadMenu()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    #endregion

}
