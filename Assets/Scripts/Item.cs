using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    a,
    b,
    etc
}

[System.Serializable]
public class Item
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;
    public int itemValue;
    public int itemCnt;

    public Item(Item other)
    {
        this.itemImage = other.itemImage;
        this.itemName = other.itemName;
        this.itemType = other.itemType;
        this.itemCnt = other.itemCnt;
        this.itemValue = other.itemValue;
    }
}