using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    //Components
    public ClothingItem item;
    public Image itemIcon;
    public TextMeshProUGUI itemName;
    private Button selectedButton;

    //Actions
    public event Action<ClothingItem> OnItemBoughtSelected;

    private void Start()
    {
        selectedButton = GetComponent<Button>();
        selectedButton.onClick.AddListener(HandleSelectClick);
    }

    private void HandleSelectClick()
    {
        OnItemBoughtSelected?.Invoke(item);
    }
}
