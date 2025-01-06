using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealPotManager : MonoBehaviour
{
    public static HealPotManager instance;

    public int healPotAmount;
    public Text healPotText;
    PlayerStats myStats;

    private int maxHealPot = 4;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        myStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (healPotAmount > 0)
            {
                UseHealPotion();
            }
        }
    }

    public void UseHealPotion()
    {
        healPotAmount--;
        myStats.currentHealth += myStats.maxHealth.GetValue() * 15 / 100;

        if(healPotAmount <= 0)
        {
            healPotAmount = 0;
        }
        healPotText.text = healPotAmount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pot")
        {
            healPotAmount += 1;

            if(healPotAmount > maxHealPot)
            {
                healPotAmount = 4;
            }
        }
        Destroy(other.gameObject);
    }
}
