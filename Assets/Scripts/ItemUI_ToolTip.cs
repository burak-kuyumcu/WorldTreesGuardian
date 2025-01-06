using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI_ToolTip : MonoBehaviour
{

    public Text itemName;
    public Text itemDescription;
    public Text itemType;

   public void ShowToolTip(ItemData item)
    {
        itemName.text=item.itemName;
        itemType.text=item.itemType.ToString();
        //
        itemDescription.text=item.GetDesc();

        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }
}
