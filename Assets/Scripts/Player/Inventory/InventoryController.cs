using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryModel inventoryModel;
    [SerializeField] private InventoryView inventoryView;
    private ClothingItem selectedClothingItem;

    private void OnEnable()
    {
        inventoryView.DisplayInventory(inventoryModel.ownedClothing);
    }

}
