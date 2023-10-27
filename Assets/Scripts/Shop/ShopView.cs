using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject clothingItemPrefab;

    public GridLayoutGroup gridLayout;
    public TextMeshProUGUI shopkeeperDialog;
    public Button buyButton;

    public event Action<ClothingItem, GameObject> OnItemSelect;
    public event Action OnBuyButtonClick;
    public event Action<ClothingItem> IfItemAlreadyBought;

    private bool isShopVisible = false;
    public bool IsShopVisible
    {
        get { return isShopVisible; }
    }

    public void DisplayShop(List<ClothingItem> items)
    {
        ClearShopItems();

        foreach (ClothingItem item in items)
        {
            CreateCloth(item);
        }
        buyButton.onClick.AddListener(() => HandleBuyButton());
    }

    public void ToggleShop(bool isVisible)
    {
        isShopVisible = isVisible;
        shopPanel.SetActive(isVisible);

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

        //If item was bought previously, disable button to prevent purchase
        if (item.isBought) 
        {
            IfItemAlreadyBought.Invoke(item);
            itemUI.GetComponent<Button>().interactable = false;
        }

        // Attach the ClothingItemScript button script to the prefab's item button
        ClothingItemScript clothingItemScript = itemUI.GetComponentInChildren<ClothingItemScript>();
        clothingItemScript.item = item;
        clothingItemScript.OnItemSelected += HandleItemSelection;
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
    }

    private void HandleBuyButton()
    {
        OnBuyButtonClick?.Invoke();
    }
}
