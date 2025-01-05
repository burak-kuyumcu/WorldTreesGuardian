using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    CharacterStats enemyStats;
    void Start()
    {
        enemyStats = GetComponent<CharacterStats>();
    }

    
    public override void Interact()
    {
        PlayerCombat playerCombat = PlayerManager.instance.player.GetComponent<PlayerCombat>();

        if(playerCombat != null)
        {
            playerCombat.Attack(enemyStats);
        }
    }
}
