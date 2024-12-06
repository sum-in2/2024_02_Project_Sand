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
    public Dictionary<Country, List<ShopItem>> shopDic = new Dictionary<Country, List<ShopItem>>();

    private void Start()
    {
        shopDic = DataManager.instance.LoadCountryCSV("CountryDB");
    }

    public List<ShopItem> GetShopItemsInCountry(string countryName)
    {
        Country country = Enum.Parse<Country>(countryName);
        return new List<ShopItem>(shopDic[country]);
    }
}
