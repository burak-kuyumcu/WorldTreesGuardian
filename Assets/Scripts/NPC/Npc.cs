using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Interactable
{
    public string[] dialouge;
    public string namenpc;
    

    public override void Interact()
    {
        DialogSystem.instance.AddNewDialouge(dialouge,namenpc);   
    }
}
