using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Image hatSlot;
    public Image dressSlot;
    public Button equipHatButton;
    public Button equipDressButton;

    public event Action<ClothingItem> OnHatEquip;
    public event Action<ClothingItem> OnDressEquip;

    private bool isInventoryVisible = false;
    public bool IsInventoryVisible
    {
        get { return isInventoryVisible; }
    }

    public void ToggleInventory(bool isVisible)
    {
        isInventoryVisible = isVisible;
        inventoryPanel.SetActive(isVisible);
    }

    public void DisplayInventory(InventoryModel inventoryModel)
    {
        if (inventoryModel.ownedClothing != null)
        {
            // Implement logic to display owned clothing in the inventory UI
        }

        if (inventoryModel.EquippedHat != null)
        {
            // Display the equipped hat in the hat slot
            hatSlot.sprite = inventoryModel.EquippedHat.sprite;
        }
        else
        {
            // Clear the hat slot if no hat is equipped
            hatSlot.sprite = null;
        }

        if (inventoryModel.EquippedDress != null)
        {
            // Display the equipped dress in the dress slot
            dressSlot.sprite = inventoryModel.EquippedDress.sprite;
        }
        else
        {
            // Clear the dress slot if no dress is equipped
            dressSlot.sprite = null;
        }
    }

    public void OnEquipHatClick()
    {
        // Implement logic to equip a hat
    }

    public void OnEquipDressClick()
    {
        // Implement logic to equip a dress
    }
}
