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
    Difficulty difficulty;

    //TODO : OnClick(판매자 이름, 난이도, 도시정보?는 일단 보류)

    public void InitList(Country _country, int _difficulty)
    {
        countryName = _country.ToString();
        difficulty = (Difficulty)_difficulty;

        traderItem = ShopDB.instance.GetItemsInCountryDifficulty(countryName, difficulty.ToString());
    }
}