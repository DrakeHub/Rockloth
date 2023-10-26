using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private ShopModel shopModel;
    [SerializeField] private ShopView shopView;
    private ClothingItem selectedClothingItem;

    private void Start()
    {
        // Events in the view
        shopView.OnItemSelect += OnItemSelected;
        shopView.OnBuyButtonClick += OnBuyButtonClicked;

        // Get the inventory model from the shop model
        InventoryModel inventoryModel = shopModel.GetInventoryModel();

        shopView.DisplayShop(shopModel.clothingInventory);

    }

    private void OnItemSelected(ClothingItem item, GameObject itemUI)
    {
        if (selectedClothingItem != null)
        {
            selectedClothingItem.isSelected = false;
        }
        item.isSelected = true;
        selectedClothingItem = item;
        shopView.DisplayShop(shopModel.clothingInventory);
    }

    private void OnBuyButtonClicked()
    {
        Debug.Log("Buy button in controller");
        if (selectedClothingItem != null)
        {
            shopModel.BuyItem(selectedClothingItem);
            selectedClothingItem = null;
            shopView.DisplayShop(shopModel.clothingInventory);
        }
    }
}
