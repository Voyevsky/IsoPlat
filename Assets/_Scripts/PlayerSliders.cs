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

    public Slider energyBar;

    void Start()
    {
        currentEnergy = startingEnergy;
        energyBar.value = 1.0f;
    }
	
    void Update()
    {
        energyBar.value = energyPercent;
    }

    void FixedUpdate()
    {
        //regenerating energy
        if(currentEnergy < startingEnergy)
        {
            currentEnergy += regenerationRate;
        }
        energyPercent = currentEnergy / startingEnergy;
        
    }

}
