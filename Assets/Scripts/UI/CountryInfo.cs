using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum Price
{
    Decrease,
    Maint,
    Increase
}

public enum Difficulty
{
    low,
    mid,
    high
}

public class CountryInfo : MonoBehaviour
{
    [HideInInspector] public CountryItems countryItems;
    List<Item> items = new List<Item>();
    [SerializeField] List<GameObject> images = new List<GameObject>();
    [SerializeField] TextMeshProUGUI countryName;
    [SerializeField] List<GameObject> dataList = new List<GameObject>();
    Dictionary<Price, List<Item>> priceData = new Dictionary<Price, List<Item>>();
    Difficulty _difficulty;

    void OnEnable()
    {
        _difficulty = countryItems.difficulty;
        InitText();
        InitData();
        InitImage();
        InstantiateItmes();
    }

    void InstantiateItmes()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/ChangePriceObject");

        foreach (GameObject obj in dataList)
        {
            DestroyChildren(obj.transform);
        }

        foreach (var kvp in priceData)
        {
            if (kvp.Value.Count != 0)
            {
                foreach (var item in kvp.Value)
                {
                    GameObject childObject = Instantiate(prefab, dataList[(int)kvp.Key].transform);
                    childObject.GetComponent<ChangePriceObject>().InitData(item, kvp.Key);
                }
            }
        }
    }

    public void DestroyChildren(Transform parent)
    {
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(parent.GetChild(i).gameObject);
        }
    }


    void InitData()
    {
        List<Item> playerData = Inventory.instance.items.ToList();
        List<Item> countryData = countryItems.itemsWithDifficulty;

        foreach (Price price in Enum.GetValues(typeof(Price)))
        {
            priceData[price] = new List<Item>();
        }

        for (int i = 0; i < playerData.Count; i++)
        {
            Item temp = countryData.FirstOrDefault(x => x.itemName == playerData[i].itemName);
            if (temp != null)
            {
                int k = temp.itemValue - playerData[i].itemValue;
                Price price = k switch
                {
                    < 0 => Price.Decrease,
                    > 0 => Price.Increase,
                    _ => Price.Maint
                };

                priceData[price].Add(temp);
                countryData.Remove(temp);
            }
        }

        priceData[Price.Maint].AddRange(countryData);
    }
    void InitImage()
    {
        items = countryItems.GetHighPriceItems(_difficulty);
        for (int i = 0; i < items.Count; i++)
            images[i].gameObject.GetComponent<Image>().sprite = items[i].itemImage;
    }

    void InitText()
    {
        countryName.text = countryItems.CountryName;
    }
}
