using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : Interactable
{
     public ItemData ItemData;
    public Texture2D cursorItem;
    public Texture2D hand;

    public override void Interact()
    {
        PickUp();
    }

    void PickUp()
    {
        Inventory.instance.AddItem(ItemData);
        Destroy(gameObject);
    }

   /* private void OnMouseOver()
    {
        Cursor.SetCursor(cursorItem,Vector2.zero,CursorMode.ForceSoftware); 
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(hand, Vector2.zero, CursorMode.ForceSoftware);
    }*/

}
