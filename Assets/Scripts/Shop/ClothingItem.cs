using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Clothing Item")]
public class ClothingItem : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
    public int price;
    public ClothingType clothingType;
    public string description;
    public bool isEquipped;
    public bool isSelected;
    public bool isBought = false;


    public void Equip(InventoryModel player)
    {
        if (!isEquipped)
        {
            isEquipped = true;
            player.UpdateEquippedOutfit(this);
        }
    }

    public void Unequip(InventoryModel player)
    {
        if (isEquipped)
        {
            isEquipped = false;
            player.UnequipOutfit(this);
        }
    }
}

public enum ClothingType
{
    Hat,
    Dress
    // Add more clothing types as needed
}