using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryModel inventoryModel;
    [SerializeField] private InventoryView inventoryView;

    private void Start()
    {
        inventoryView.OnHatEquip += EquipHat;
        inventoryView.OnDressEquip += EquipDress;
    }

    private void EquipHat(ClothingItem hatItem)
    {
        // Implement logic to equip a hat
        inventoryModel.UpdateEquippedOutfit(hatItem);
        inventoryView.DisplayInventory(inventoryModel);
    }

    private void EquipDress(ClothingItem dressItem)
    {
        // Implement logic to equip a dress
        inventoryModel.UpdateEquippedOutfit(dressItem);
        inventoryView.DisplayInventory(inventoryModel);
    }

    // Implement methods to handle UI interactions, such as opening and closing the inventory
}
