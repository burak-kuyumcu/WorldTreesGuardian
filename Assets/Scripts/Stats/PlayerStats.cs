using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    public Image healthBar;

    private void Update()
    {
        healthBar.fillAmount = currentHealth / maxHealth.GetValue();
    }
    public override void Die()
    {
       
    }
}
