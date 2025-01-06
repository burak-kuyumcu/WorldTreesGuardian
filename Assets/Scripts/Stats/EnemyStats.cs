using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : CharacterStats
{
    public Image enemyHealthBar;

    Animator anim;
    public float givenExperience=5;

    LootSystem loot;

    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        loot = GetComponent<LootSystem>();
    }


    // Update is called once per frame
    void Update()
    {
        enemyHealthBar.fillAmount = currentHealth / maxHealth.GetValue();
    }

    public override void Die()
    {
        PlayerManager.instance.player.GetComponent<LevelManager>().SetExperience(givenExperience);
        anim.SetTrigger("Die");
        Destroy(gameObject, 4f);
        loot.DropItem();
    }
}
