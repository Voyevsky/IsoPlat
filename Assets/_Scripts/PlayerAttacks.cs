using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{

    public Collider basicAttackHitbox;
    public Collider specialAttackHitbox;

    public float attackCooldown = 0.33f;

    public float specialDamage = 50;

    public bool isAttacking = false;
    public bool isPerformingSpecial = false;
    private float attackTimePassed = 0f;

    [SerializeField] private GameObject fireball;

    private int spellId = 0;

    //Spells' ID: 0 = fireball, 1 = pillar, 2 = AoE

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
                isPerformingSpecial = false;
            }
        }

        if (Input.GetButtonDown("Magic"))
        {
            CastSpell(spellId);
        }

        SpellSelect();

    }

    #region Attacks
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
    #endregion

    #region Magic

    void SpellSelect()
    {
        if (Input.GetAxisRaw("DPadVer") > 0 || Input.GetButtonDown("SpellOne"))
        {
            spellId = 0;
            Debug.Log("Selected: Fireball");
        }
        if (Input.GetAxisRaw("DPadHor") > 0 || Input.GetButtonDown("SpellThree"))
        {
            spellId = 1;
            Debug.Log("Selected: Pillar");
        }
        if (Input.GetAxisRaw("DPadVer") < 0 || Input.GetButtonDown("SpellTwo"))
        {
            spellId = 2;
            Debug.Log("Selected: AoE");
        }
        
        if(Input.GetButtonDown("CycleSpells"))
        {
            spellId++;
            if(spellId > 2)
            {
                spellId = 0;
            }
            Debug.Log(spellId);
        }
    }

    void CastSpell(int id)
    {
        switch(id)
        {
            case 1:
                Debug.Log("Pillar!");
                break;
            case 2:
                Debug.Log("AoE!");
                break;
            default:
                Fireball();
                break; 
        }
    }

    void Fireball()
    {
        if (gameObject.GetComponent<PlayerEnergyBars>().currentMana >= 30.0f)
        {
            gameObject.GetComponent<PlayerEnergyBars>().currentMana -= 30.0f;
                
            var boolet = Instantiate(fireball);
            boolet.transform.position = transform.position;

            Debug.Log("Fireball!");
        }
        
    }

    void Pillar()
    {
        if (gameObject.GetComponent<PlayerEnergyBars>().currentMana >= 30.0f)
        {
            gameObject.GetComponent<PlayerEnergyBars>().currentMana -= 30.0f;
            Debug.Log("Pillar!");
        }
    }

    void AoE()
    {
        if (gameObject.GetComponent<PlayerEnergyBars>().currentMana >= 70.0f)
        {
            gameObject.GetComponent<PlayerEnergyBars>().currentMana -= 70.0f;
            Debug.Log("AoE!");
        }
    }

    #endregion

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
