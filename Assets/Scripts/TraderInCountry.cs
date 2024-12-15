using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class TraderInCountry : MonoBehaviour
{
    public List<GameObject> traderGameObjects = new List<GameObject>();
    public Dictionary<(String traderName, int Level), List<Item>> traderItemDictionary;
    public TextMeshProUGUI countryName;
    List<Trader> traderDB;
    List<(String, int)> traderList;

    public void InitTraders(List<Item> items, Difficulty difficulty, string _countryName)
    {
        traderItemDictionary = new Dictionary<(string, int), List<Item>>();
        traderList = new List<(String, int)>();

        if (Enum.TryParse<Country>(_countryName, out Country country))
        {
            traderDB = TraderDB.instance.traderDB[(country, difficulty)];
            var itemDictionary = items.ToDictionary(item => item.itemName);

            foreach (Trader trader in traderDB)
            {
                var tuple = (trader.traderName, trader.level);
                if (!traderItemDictionary.ContainsKey(tuple))
                    traderItemDictionary[tuple] = new List<Item>();

                if (!traderList.Contains(tuple))
                    traderList.Add(tuple);

                if (itemDictionary.TryGetValue(trader.itemName, out Item item))
                {
                    traderItemDictionary[tuple].Add(new Item(item.itemImage, item.itemName, item.itemValue, trader.itemCnt));
                }
            }
        }

        countryName.text = _countryName;

        for (int i = 0; i < traderList.Count(); i++)
        {
            var tuple = traderList[i];
            traderGameObjects[i].GetComponent<TraderInfo>().InitTrader(tuple, traderItemDictionary[tuple]);
        }
    }
}
