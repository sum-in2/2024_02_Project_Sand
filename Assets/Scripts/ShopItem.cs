using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty
{
    low,
    mid,
    high
}

[System.Serializable]
public class ShopItem
{
    public Difficulty difficulty;
    public string itemName;
    public int itemValue;
    public int itemCnt;

    public ShopItem(string _itemName, Difficulty _difficulty, int _itemValue, int _itemCnt)
    {
        difficulty = _difficulty;
        itemName = _itemName;
        itemValue = _itemValue;
        itemCnt = _itemCnt;
    }
}
