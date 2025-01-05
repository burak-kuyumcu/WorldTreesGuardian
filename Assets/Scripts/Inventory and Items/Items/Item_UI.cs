using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item_UI : MonoBehaviour,IPointerDownHandler
{
    public Image itemImage;
    public Text itemAmount;

    public InventoryItem item;

    public void OnPointerDown(PointerEventData eventData)
    {
        Inventory.instance.EquipItem(item.data);
    }

    public void UpdateSlotsUI(InventoryItem newItem)
    {
        item = newItem;
        if(item != null)
        {
            itemImage.sprite = item.data.itemIcon;
            if (item.stackSize > 1)
            {
                itemAmount.text = item.stackSize.ToString();

            }
            else
            {
                itemAmount.text = "";
            }

        }
    }

    public void CleanUp()
    {
        item = null;
        itemAmount.text = "";
        itemImage.sprite = null;
    }
}
