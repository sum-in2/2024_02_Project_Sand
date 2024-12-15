using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class CountryDB : MonoBehaviour
{
    #region Singleton

    public static CountryDB instance;
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

    public List<Item> GetItemsInCountryDifficulty(string countryName, Difficulty difficulty)
    {
        if (Enum.TryParse(countryName, out Country _country))
            return new List<Item>(shopDic[(_country, difficulty)]);
        else
            return null;
    }
}
