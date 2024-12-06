using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class TraderInventory : MonoBehaviour
{
    #region Singleton

    public static TraderInventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }
    #endregion

    public List<Item> traderItem = new List<Item>();
    public List<Item> traderExchange = new List<Item>();
    string countryName;
    string traderName;
    int level;

    public void InitList(Country _country, int _level)
    {
        countryName = _country.ToString();
        level = _level;
        traderItem = ShopItemListToItemList(ShopDB.instance.GetShopItemsInCountry(countryName));
        traderExchange = ReturnTraderList();
    }

    List<Item> ShopItemListToItemList(List<ShopItem> value)
    {
        List<Item> list = new List<Item>();

        foreach (ShopItem shopItem in value)
        {
            Item item = new Item(ItemDB.instance.GetItemByName(shopItem.itemName));
            if (item != null)
            {
                item.itemCnt = shopItem.itemCnt;
                item.itemValue = shopItem.itemValue;
                list.Add(item);
            }
        }

        return list;
    }

    List<Item> ReturnTraderList()
    {
        List<Item> returnList = new List<Item>();

        int count = Math.Min(level, traderItem.Count);
        var random = new System.Random();
        var randomIndices = Enumerable.Range(1, traderItem.Count)
                                      .OrderBy(x => random.Next())
                                      .Take(count)
                                      .ToList();

        foreach (var index in randomIndices)
        {
            Item temp = traderItem[index];
            temp.itemCnt = random.Next(1, temp.itemCnt);
            returnList.Add(new Item(temp));
        }

        return returnList;
    }
}