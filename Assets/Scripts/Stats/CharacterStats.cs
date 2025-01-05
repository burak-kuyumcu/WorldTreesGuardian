using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public Stat damage;
    public Stat maxHealth;
    public Stat strength;
    public Stat agility;
    public Stat critChance;
    public Stat critPower;

    [HideInInspector]
    public float currentHealth;
   public virtual void Start()
    {
        currentHealth = maxHealth.GetValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float CalculatedDamage()
    {
        float totalDamage=damage.GetValue()+strength.GetValue()*2;


        if (CanCrit())
        {
            totalDamage = CalculatedCriticalDamage();
        }
        return totalDamage;
    }

    private float CalculatedCriticalDamage()
    {
        float totalCritDamage = (damage.GetValue() + strength.GetValue() * 2) * 1.5f;
        return totalCritDamage;
    }

    private bool CanCrit()
    {
        float finalCriticalChance=critChance.GetValue()+agility.GetValue()*1.5f;

        if (Random.Range(0, 100)<finalCriticalChance)
        {
            return true;
        }
        return false;
    }

    public float CalculatedCriticalChance()
    {
        float finalCriticalChance= critChance.GetValue() + agility.GetValue() *.25f;
        return finalCriticalChance;
    }


    public virtual void takeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
