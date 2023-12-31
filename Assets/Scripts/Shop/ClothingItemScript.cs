using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClothingItemScript : MonoBehaviour
{
    //Components
    public ClothingItem item;
    public Image itemIcon;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemPrice;
    private Button buyButton;

    //Actions
    public event Action<ClothingItem, GameObject> OnItemSelected;

    private void Start()
    {
        buyButton = GetComponent<Button>();
        buyButton.onClick.AddListener(HandleButtonClick);

        // Initialize UI elements with item data
        itemIcon.sprite = item.sprite;
        itemName.text = item.itemName;
        itemPrice.text = item.price.ToString();
    }

    private void HandleButtonClick()
    {
        if (!item.isBought)
        {
            OnItemSelected?.Invoke(item, this.gameObject);
        }
    }
}