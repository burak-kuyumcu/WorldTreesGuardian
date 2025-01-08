using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel; // Panel'in kendisini referans alýyoruz

    private bool isInventoryOpen = false; // Envanter açýk mý?

    void Update()
    {
        // "I" tuþuna basýldýðýnda envanteri aç/kapa
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen; // Envanter durumunu deðiþtir
        inventoryPanel.SetActive(isInventoryOpen); // Panel'i aç/kapa
    }
}

