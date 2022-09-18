using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Image icon;
    public Button unequipButton;
    public EquipmentTypeSO equipmentType;

    EquipmentItem equipmentItem;

    public EquipmentSO playerEquipment;

    public void AddItem(EquipmentItem newItem)
    {
        equipmentItem = newItem;

        icon.sprite = equipmentItem.icon;
        icon.enabled = true;
        unequipButton.interactable = true;
    }

    public void ClearSlot()
    {
        equipmentItem = null;

        icon.sprite = null;
        icon.enabled = false;
        unequipButton.interactable = false;
    }

    public void RemoveEquipment()
    {
        playerEquipment.Unequip(equipmentItem);
       // MasterSingleton.Instance.EquipmentManager.Unequip(equipmentItem);
    }
}