using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject inventory;
    public GameObject inventoryText;

    public GameObject characterPanel;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(inventory.activeSelf)
            {
                HideInventory();
            }
            else if (!inventory.activeSelf)
            {
                ShowInventory();
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (characterPanel.activeSelf)
            {
                characterPanel.SetActive(false);
            }
            else if (!characterPanel.activeSelf)
            {
                characterPanel.SetActive(true);
            }
        }
    }
    public void ShowInventory()
    {
        inventory.SetActive(true);
        inventoryText.SetActive(true);
    }
    public void HideInventory()
    {
        inventory.SetActive(false);
        inventoryText.SetActive(false);
    }
}
