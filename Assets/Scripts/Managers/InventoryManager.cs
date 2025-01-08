using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel; // Panel'in kendisini referans al�yoruz

    private bool isInventoryOpen = false; // Envanter a��k m�?

    void Update()
    {
        // "I" tu�una bas�ld���nda envanteri a�/kapa
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen; // Envanter durumunu de�i�tir
        inventoryPanel.SetActive(isInventoryOpen); // Panel'i a�/kapa
    }
}

