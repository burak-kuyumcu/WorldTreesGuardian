using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public GameObject equipmentPanel; // Panel'in kendisini referans al�yoruz

    private bool isEquipmentOpen = false; // Envanter a��k m�?

    void Update()
    {
        // "I" tu�una bas�ld���nda envanteri a�/kapa
        if (Input.GetKeyDown(KeyCode.O))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isEquipmentOpen = !isEquipmentOpen; // Envanter durumunu de�i�tir
        equipmentPanel.SetActive(isEquipmentOpen); // Panel'i a�/kapa
    }
}
