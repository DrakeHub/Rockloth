using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopModel : MonoBehaviour
{
    public List<ClothingItem> clothingInventory;
    [SerializeField] private InventoryModel inventoryModel;

    public event Action<ClothingItem> OnPurchase;

    public void Initialize(InventoryModel inventory)
    {
        inventoryModel = inventory;
    }

    public void BuyItem(ClothingItem item)
    {

        if (CanPlayerAfford(item) && !inventoryModel.IsItemOwned(item))
        {
            inventoryModel.SpendCurrency(item.price);
            inventoryModel.AddToOwnedItems(item);
            item.isBought = true;
            OnPurchase?.Invoke(item);
        }
    }

    public void AddBoughtToInventory(ClothingItem item)
    {
        if (!inventoryModel.IsItemOwned(item))
        {
            inventoryModel.AddToOwnedItems(item);
        }
    }

    private bool CanPlayerAfford(ClothingItem item)
    {
        return inventoryModel.GetInGameCurrency() >= item.price;
    }

    public InventoryModel GetInventoryModel()
    {
        if (inventoryModel != null)
        {
            return inventoryModel;
        }
        return null;
    }
}