using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public Dictionary<ItemData, InventoryItem> inventoryDictionary = new Dictionary<ItemData, InventoryItem>();

    public List<InventoryItem> equipment = new List<InventoryItem>();
    public Dictionary<ItemData, InventoryItem> equipmentDictionary = new Dictionary<ItemData, InventoryItem>();

    public Transform inventorySlot;
    public Item_UI[] itemSlot;

    public Transform equipmentSlotParent;
    public EquipmentSlot_UI[] equipmentSlots;

    private void Start()
    {
        itemSlot = inventorySlot.GetComponentsInChildren<Item_UI>();
        equipmentSlots = equipmentSlotParent.GetComponentsInChildren<EquipmentSlot_UI>();

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EquipItem(ItemData _item)
    {
        ItemData newEquipment = _item as ItemData;
        InventoryItem newItem = new InventoryItem(newEquipment);

        ItemData oldEquipment = null;

        foreach (KeyValuePair<ItemData, InventoryItem> item in equipmentDictionary)
        {
            if (item.Key.itemType == _item.itemType)
            {
                oldEquipment = item.Key;  
            }
        }

        if(oldEquipment != null)
        {
            UnEquipment(oldEquipment);
        }
        equipment.Add(newItem);
        equipmentDictionary.Add(newEquipment, newItem);

        UpdateUI();
        RemoveItem(_item);

        newEquipment.AddModifiers();
    }

    public void UnEquipment(ItemData removedItem)
    {
        if (equipmentDictionary.TryGetValue(removedItem, out InventoryItem value))
        {
            AddItem(removedItem);
            equipment.Remove(value);
            equipmentDictionary.Remove(removedItem);
            removedItem.RemoveModifiers();
        }
    }


    public void AddItem(ItemData item) 
    {
        if (inventoryDictionary.TryGetValue(item, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(item);
            inventoryItems.Add(newItem);
            inventoryDictionary.Add(item, newItem);
        }
        UpdateUI();

    }

    public void RemoveItem(ItemData item)
    {

        if (inventoryDictionary.TryGetValue(item, out InventoryItem value))
        {
            if(value.stackSize <= 1)
            {
                inventoryItems.Remove(value);
                inventoryDictionary.Remove(item);
            }
            else
            {
                value.RemoveStack();
            }
        }

        UpdateUI();

    }

    void UpdateUI()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            foreach (KeyValuePair<ItemData,InventoryItem> item in equipmentDictionary)
            {
                if (item.Key.itemType == equipmentSlots[i].equipmentType)
                {
                    equipmentSlots[i].UpdateSlotsUI(item.Value);
                }
            }   
        }



        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].CleanUp();
        }


        for (int i = 0; i < inventoryItems.Count; i++) 
        {
            itemSlot[i].UpdateSlotsUI(inventoryItems[i]);
        }

    }

}
