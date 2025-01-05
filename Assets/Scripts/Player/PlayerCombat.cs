using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    public float attackCountdown = 0f;

    PlayerStats myStats;
    void Start()
    {
        myStats = GetComponent<PlayerStats>();  
    }

    // Update is called once per frame
    void Update()
    {
        attackCountdown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if (attackCountdown <= 0)
        {
            targetStats.takeDamage(myStats.CalculatedDamage());
            attackCountdown = 1f / attackSpeed;
        }
    }
}
