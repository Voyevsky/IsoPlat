using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilField : MonoBehaviour
{
    //succ health
    [SerializeField] private PlayerEnergyBars healthAndStuff;
    private bool succHealth = false;
    [SerializeField] private float succRate = 0.5f;

    void FixedUpdate()
    {
        if (succHealth)
        {
            healthAndStuff.currentHealth -= succRate;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            succHealth = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            succHealth = false;
        }
    }

}
