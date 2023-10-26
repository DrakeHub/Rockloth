using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    public GridLayoutGroup gridLayout;
    public GameObject clothingItemPrefab;
    public TextMeshProUGUI shopkeeperDialog;
    public Button buyButton;

    public event Action<ClothingItem, GameObject> OnItemSelect; // To inform Controller
    public event Action OnBuyButtonClick;

    public void DisplayShop(List<ClothingItem> items)
    {
        ClearShopItems();

        foreach (ClothingItem item in items)
        {
            CreateCloth(item);
        }
        buyButton.onClick.AddListener(() => HandleBuyButton());
    }
    private void CreateCloth(ClothingItem item)
    {
        //Get all prefab components
        GameObject itemUI = Instantiate(clothingItemPrefab, gridLayout.transform);
        Image itemIcon = itemUI.transform.Find("ItemImage").GetComponent<Image>();
        TMPro.TextMeshProUGUI itemNameText = itemUI.transform.Find("Name").GetComponent<TMPro.TextMeshProUGUI>();
        TMPro.TextMeshProUGUI itemPriceText = itemUI.transform.Find("Price").GetComponent<TMPro.TextMeshProUGUI>();

        //Initialize Clothing Item with Clothing Item data
        itemIcon.sprite = item.sprite;
        itemNameText.text = item.itemName;
        itemPriceText.text = item.price.ToString();
        itemIcon.color = item.isSelected ? Color.yellow : Color.white;

        //Disable button to prevent purchase
        if (item.isBought) 
        { 
           itemUI.GetComponent<Button>().interactable = false;
        }

        // Attach the ClothingItemScript button script to the prefab's item button
        ClothingItemScript clothingItemScript = itemUI.GetComponentInChildren<ClothingItemScript>();
        clothingItemScript.item = item;
        clothingItemScript.OnItemSelected += HandleItemSelection;
    }
    public void ShowShopkeeperDialog(string dialog)
    {
        shopkeeperDialog.text = dialog;
    }

    private void ClearShopItems()
    {
        foreach (Transform child in gridLayout.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void HandleItemSelection(ClothingItem item, GameObject prefab)
    {
        // Trigger the item selection event
        OnItemSelect?.Invoke(item, prefab);
        //Debug.Log(item, prefab);
    }

    private void HandleBuyButton()
    {
        // Handle the purchase logic here, using the selected item
        // For example, deduct the item's price from the player's currency

        // Trigger the "Buy" button click event
        OnBuyButtonClick?.Invoke();
    }
}
