using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : MonoBehaviour
{
    public List<ClothingItem> ownedClothing;

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
}
