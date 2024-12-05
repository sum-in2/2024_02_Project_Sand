using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class ShopDB : MonoBehaviour
{
    #region Singleton

    public static ShopDB instance;
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

    // TODO : DB 입출력 함수
    public Dictionary<string, List<ShopItem>> shopDic = new Dictionary<string, List<ShopItem>>
    {
        {
            "test1", new List<ShopItem>
            {
                new ShopItem { itemName = "test1", itemValue = 15, itemCnt = 1 },
                new ShopItem { itemName = "test2", itemValue = 20, itemCnt = 6 },
                new ShopItem { itemName = "test3", itemValue = 30, itemCnt = 3 }
            }
        },
        {
            "test2", new List<ShopItem>
            {
                new ShopItem { itemName = "test2", itemValue = 40, itemCnt = 4 },
                new ShopItem { itemName = "test3", itemValue = 10, itemCnt = 2 },
                new ShopItem { itemName = "test5", itemValue = 50, itemCnt = 2 }
            }
        }
    };

    public List<ShopItem> GetShopItemsInCountry(string countryName)
    {
        return new List<ShopItem>(shopDic[countryName]);
    }
}
