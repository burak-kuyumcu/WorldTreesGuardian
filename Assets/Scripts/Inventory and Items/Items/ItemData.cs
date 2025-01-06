using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.VersionControl;
using System.Text;

public enum EquipmentType
{
    Weapon,
    Armor, //Helmet,Chest,Hand,Leg,Feet
    Ring,
    Trinket
}

[CreateAssetMenu(fileName ="New Item Data", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public EquipmentType itemType;

    public string itemName;
    public Sprite itemIcon;

    public float agility;
    public float strength;
    public float damage;
    public float critChance;
    public float critPower;

    protected StringBuilder sb=new StringBuilder();


    public void AddModifiers()
    {
        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();

        playerStats.strength.AddModifiers(strength);
        playerStats.agility.AddModifiers(agility);


        playerStats.damage.AddModifiers(damage);


        playerStats.critChance.AddModifiers(critChance);
        playerStats.critPower.AddModifiers(critPower);

    }

    public void RemoveModifiers()
    {
        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();

        playerStats.strength.RemoveModifiers(strength);
        playerStats.agility.RemoveModifiers(agility);


        playerStats.damage.RemoveModifiers(damage);


        playerStats.critChance.RemoveModifiers(critChance);
        playerStats.critPower.RemoveModifiers(critPower);

    }


    private void AddItemDescription(float _value,string _name)
    {
        if(_value!=0)
        {
            if(sb.Length > 0)
            {
                sb.AppendLine();
            }
            if(_value>0)
            {
                sb.Append(" "+_name+":"+_value);
            }
        }
    }

    public string GetDesc()
    {
        sb.Length = 0;
        AddItemDescription(strength, "Strength");
        AddItemDescription(damage, "Damage");
        AddItemDescription(agility, "Agility");

        return sb.ToString();
    }


}
