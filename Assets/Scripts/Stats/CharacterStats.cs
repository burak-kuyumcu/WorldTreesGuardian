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


    private float currentHealth;
   public virtual void Start()
    {
        currentHealth = maxHealth.GetValue();
    }

    // Update is called once per frame
    void Update()
    {
        
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
