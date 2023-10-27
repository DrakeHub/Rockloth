using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject inventoryItemPrefab;

    private GameObject hatInstance;
    private GameObject torsoInstance;

    public PlayerController player;

    [SerializeField] private List<GameObject> hatPrefabs;
    private bool hatCreated;
    [SerializeField] private List<GameObject> torsoPrefabs;
    private bool torsoCreated;


    public GridLayoutGroup gridLayout;
    public Image hatSlot;
    public Image torsoSlot;

    private bool isInventoryVisible = false;
    public bool IsInventoryVisible
    {
        get { return isInventoryVisible; }
    }

    public void DisplayInventory(List<ClothingItem> items)
    {
        ClearInventoryItems();

        foreach (ClothingItem item in items)
        {
            CreateBoughtCloth(item);
            Debug.Log("aDDED");
        }
    }
    public void ToggleInventory(bool isVisible)
    {
        isInventoryVisible = isVisible;
        inventoryPanel.SetActive(isVisible);
        
    }
    private void CreateBoughtCloth(ClothingItem item)
    {
        //Get all prefab components
        GameObject itemUI = Instantiate(inventoryItemPrefab, gridLayout.transform);
        Image itemIcon = itemUI.transform.Find("ItemImage").GetComponent<Image>();
        TMPro.TextMeshProUGUI itemNameText = itemUI.transform.Find("Name").GetComponent<TMPro.TextMeshProUGUI>();

        //Initialize Clothing Item with Clothing Item data
        itemIcon.sprite = item.sprite;
        itemNameText.text = item.itemName;

        // Attach the ClothingItemScript button script to the prefab's item button
        InventoryItem inventoryItemScript = itemUI.GetComponentInChildren<InventoryItem>();
        inventoryItemScript.item = item;
        inventoryItemScript.OnItemBoughtSelected += HandleBoughtItemSelection;
    }

    private void HandleBoughtItemSelection(ClothingItem item)
    {
        if(item.clothingType == ClothingType.Hat)
        {
            hatSlot.gameObject.SetActive(true);
            hatSlot.sprite = item.sprite;
            for (int i = 0; i < hatPrefabs.Count; i++)
            {
                if (item.itemName == hatPrefabs[i].name)
                {
                    if (hatInstance != null)
                    {                        
                        Destroy(hatInstance);
                        hatInstance = null;

                    }
                    if (hatInstance == null)
                    {
                        hatInstance = Instantiate(hatPrefabs[i]);
                        hatInstance.transform.parent = player.gameObject.transform;
                        hatInstance.transform.position = player.transform.position;
                        hatCreated = true;

                        player.hatAnimator =  hatInstance.GetComponent<Animator>();

                    }
                }
            }
        }
        else if (item.clothingType == ClothingType.Torso)
        {
            torsoSlot.gameObject.SetActive(true);
            torsoSlot.sprite = item.sprite;
            for (int i = 0; i < torsoPrefabs.Count; i++)
            {
                if (item.itemName == torsoPrefabs[i].name)
                {
                    if (torsoInstance != null)
                    {
                        Destroy(torsoInstance);
                        torsoInstance = null;

                    }
                    if (torsoInstance == null)
                    {
                        torsoInstance = Instantiate(torsoPrefabs[i]);
                        torsoInstance.transform.parent = player.gameObject.transform;
                        torsoInstance.transform.position = player.transform.position;
                        torsoCreated = true;

                        player.torsoAnimator = torsoInstance.GetComponent<Animator>();

                    }
                }
            }
        }
    }

    private void ClearInventoryItems()
    {
        foreach (Transform child in gridLayout.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
