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

}

public enum ClothingType
{
    Hat,
    Torso
}