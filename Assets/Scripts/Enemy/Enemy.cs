using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Interactable
{
    CharacterStats enemyStats;

    public Texture2D cursorItem;
    public Texture2D hand;

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
            PlayerManager.instance.player.GetComponent<PlayerMovement>().anim.SetTrigger("Attack");
            
        }
    }

    private void OnMouseOver()
    {
        Cursor.SetCursor(cursorItem,Vector2.zero,CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(hand, Vector2.zero, CursorMode.ForceSoftware);
    }
}
