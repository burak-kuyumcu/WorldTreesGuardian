using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public GameObject equipmentPanel; // Panel'in kendisini referans alýyoruz

    private bool isEquipmentOpen = false; // Envanter açýk mý?

    void Update()
    {
        // "I" tuþuna basýldýðýnda envanteri aç/kapa
        if (Input.GetKeyDown(KeyCode.O))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isEquipmentOpen = !isEquipmentOpen; // Envanter durumunu deðiþtir
        equipmentPanel.SetActive(isEquipmentOpen); // Panel'i aç/kapa
    }
}
