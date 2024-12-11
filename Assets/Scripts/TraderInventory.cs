using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class TraderInventory : MonoBehaviour
{
    public List<Item> traderItem = new List<Item>();
    public List<Item> traderExchange = new List<Item>();
    string countryName;
    string traderName;
    Difficulty difficulty;

    //TODO : OnClick(판매자 이름, 난이도, 도시정보?는 일단 보류)
    private void Start()
    {
        countryName = gameObject.name;
        InitList(1);
    }

    public void InitList(int _difficulty)
    {
        difficulty = (Difficulty)_difficulty;

        traderItem = ShopDB.instance.GetItemsInCountryDifficulty(countryName, difficulty.ToString());
    }
}