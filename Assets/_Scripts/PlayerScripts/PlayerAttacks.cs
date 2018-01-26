using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private PlayerController player;
    public Collider basicAttackHitbox;
    public Collider specialAttackHitbox;

    public float attackCooldown = 0.33f;

    public float specialDamage = 50;

    public float fireballCost = 30;
    public float pillarCost = 40;
    public float aoeCost = 70;

    public static bool isAttacking = false;
    public bool isPerformingSpecial = false;
    private float attackTimePassed = 0f;

    [SerializeField] private GameObject fireball;
    [SerializeField] private GameObject pillar;
    [SerializeField] private GameObject pillarSpawnPoint;
    [SerializeField] private GameObject AoEPrefab;

    [SerializeField] private GameObject UIFireball;
    [SerializeField] private GameObject UIPillar;
    [SerializeField] private GameObject UIAoE;

    private Vector3 AoECorrection = new Vector3(0f, -0.6f, 0f);

    //[SerializeField] private GameObject player;
    //[SerializeField] private Animator playerAnim;

    private int spellId = 0;

    //Spells' ID: 0 = fireball, 1 = pillar, 2 = AoE

    void Start()
    {
        player = gameObject.GetComponentInParent<PlayerController>();
        basicAttackHitbox.enabled = false;
        specialAttackHitbox.enabled = false;

        UIFireball.SetActive(true);
        UIPillar.SetActive(false);
        UIAoE.SetActive(false);
    }

    void Update()
    {
        Deactivate();
        if (PlayerController.isAlive)
        {
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
            UIFireball.SetActive(true);
            UIPillar.SetActive(false);
            UIAoE.SetActive(false);
        }
        if (Input.GetAxisRaw("DPadHor") > 0 || Input.GetButtonDown("SpellTwo"))
        {
            spellId = 1;
            UIFireball.SetActive(false);
            UIPillar.SetActive(true);
            UIAoE.SetActive(false);
        }
        if (Input.GetAxisRaw("DPadVer") < 0 || Input.GetButtonDown("SpellThree"))
        {
            spellId = 2;
            UIFireball.SetActive(false);
            UIPillar.SetActive(false);
            UIAoE.SetActive(true);
        }
        
        if(Input.GetButtonDown("CycleSpells"))
        {
            spellId++;
            if(spellId > 2)
            {
                spellId = 0;
            }
            switch(spellId)
            {
                case 0:
                    UIFireball.SetActive(true);
                    UIPillar.SetActive(false);
                    UIAoE.SetActive(false);
                    break;
                case 1:
                    UIFireball.SetActive(false);
                    UIPillar.SetActive(true);
                    UIAoE.SetActive(false);
                    break;
                case 2:
                    UIFireball.SetActive(false);
                    UIPillar.SetActive(false);
                    UIAoE.SetActive(true);
                    break;
            }
            Debug.Log(spellId);
        }
    }

    void CastSpell(int id)
    {
        switch(id)
        {
            case 1:
                Pillar();
                break;
            case 2:
                AoE();
                break;
            default:
                Fireball();
                break; 
        }
    }

    void Fireball()
    {
        if (gameObject.GetComponent<PlayerEnergyBars>().currentMana >= fireballCost)
        {
            gameObject.GetComponent<PlayerEnergyBars>().currentMana -= fireballCost;
                
            var boolet = Instantiate(fireball);
            boolet.transform.position = transform.position;
        }
        
    }

    void Pillar()
    {
        if (gameObject.GetComponent<PlayerEnergyBars>().currentMana >= pillarCost)
        {
            gameObject.GetComponent<PlayerEnergyBars>().currentMana -= pillarCost;

            var pillarOfMagic = Instantiate(pillar);
            pillarOfMagic.transform.position = pillarSpawnPoint.transform.position;
        }
    }

    void AoE()
    {
        if (gameObject.GetComponent<PlayerEnergyBars>().currentMana >= aoeCost && player.grounded)
        {
            gameObject.GetComponent<PlayerEnergyBars>().currentMana -= aoeCost;

            var AoEMagic = Instantiate(AoEPrefab);
            AoEMagic.transform.position = transform.position;
            AoEMagic.transform.position = AoEMagic.transform.position + AoECorrection;
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
