using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemImage;
    public int itemValue;
    public int itemCnt;

    public Item(Item other)
    {
        this.itemImage = other.itemImage;
        this.itemName = other.itemName;
        this.itemCnt = other.itemCnt;
        this.itemValue = other.itemValue;
    }

    public Item(Item other, int _itemCnt)
    {
        this.itemImage = other.itemImage;
        this.itemName = other.itemName;
        this.itemCnt = _itemCnt;
        this.itemValue = other.itemValue;
    }

    public Item(Sprite _itemImage, string _itemName, int _itemValue, int _itemCnt)
    {
        this.itemImage = _itemImage;
        this.itemName = _itemName;
        this.itemValue = _itemValue;
        this.itemCnt = _itemCnt;
    }
}