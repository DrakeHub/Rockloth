using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : MonoBehaviour
{
    public List<ClothingItem> ownedClothing = new List<ClothingItem>();

    private int inGameCurrency;
    public ClothingItem EquippedHat { get; private set; }
    public ClothingItem EquippedDress { get; private set; }

    private void Start()
    {
        inGameCurrency = 9999;
    }

    public int GetInGameCurrency()
    {
        return inGameCurrency;
    }

    public bool IsItemOwned(ClothingItem item)
    {
        return ownedClothing.Contains(item);
    }

    public void SpendCurrency(int amount)
    {
        inGameCurrency -= amount;
    }

    public void AddToOwnedItems(ClothingItem item)
    {
        ownedClothing.Add(item);
        Debug.Log("Added");
    }

    public void UpdateEquippedOutfit(ClothingItem item)
    {
        if (item.clothingType == ClothingType.Hat)
        {
            EquippedHat = item;
        }
        else if (item.clothingType == ClothingType.Dress)
        {
            EquippedDress = item;
        }
        // Implement logic to equip the item on the player's character
    }

    public void UnequipOutfit(ClothingItem item)
    {
        if (item.clothingType == ClothingType.Hat)
        {
            EquippedHat = null;
        }
        else if (item.clothingType == ClothingType.Dress)
        {
            EquippedDress = null;
        }
        // Implement logic to unequip the item from the player's character
    }
}
