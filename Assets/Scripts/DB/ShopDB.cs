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
        shopDic = DataManager.instance.LoadCountryCSV("CountryDB");
    }
    #endregion

    public Dictionary<(Country, Difficulty), List<Item>> shopDic = new Dictionary<(Country, Difficulty), List<Item>>();

    private void Start()
    {
    }

    public List<Item> GetItemsInCountryDifficulty(string countryName, string difficulty)
    {
        if (Enum.TryParse(countryName, out Country _country) &&
            Enum.TryParse(difficulty, out Difficulty _difficulty))
            return new List<Item>(shopDic[(_country, _difficulty)]);
        else
            return null;
    }
}
