using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    //Components
    [SerializeField] private Image itemIcon;

    private void UpdateData(ClothingItem item)
    {
        if (item != null)
        {
            itemIcon.gameObject.SetActive(true);
            this.GetComponent<Image>().sprite = item.sprite;
        }
    }

}