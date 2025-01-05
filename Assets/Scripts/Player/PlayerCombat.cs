using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    public float attackCountdown = 0f;
    void Start()
    {
        
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
            targetStats.takeDamage(10f);
            attackCountdown = 1f / attackSpeed;
        }
    }
}
