using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot_UI : Item_UI
{
    public EquipmentType equipmentType;
    public Image dummyCharacter;

    public override void OnPointerDown(PointerEventData eventData)
    {
        Inventory.instance.UnEquipment(item.data as ItemData);
        item = null;
        itemImage.sprite = dummyCharacter.sprite;
    }
}
