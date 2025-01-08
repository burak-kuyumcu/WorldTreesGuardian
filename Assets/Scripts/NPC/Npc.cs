using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc : Interactable
{
    public string[] dialouge;
    public string namenpc;

    public Texture2D cursorItem;
    public Texture2D hand;


    public override void Interact()
    {
        DialogSystem.instance.AddNewDialouge(dialouge,namenpc);   
    }

   /* private void OnMouseOver()
    {
        Cursor.SetCursor(cursorItem, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(hand, Vector2.zero, CursorMode.ForceSoftware);
    }*/
}
