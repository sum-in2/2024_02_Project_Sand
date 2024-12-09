using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    #region Singleton

    public static ItemDB instance;
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

    public List<Item> itemList = new List<Item>();

    private void Start()
    {
        itemList = DataManager.instance.LoadItemCSV("ItemDB");
    }

    public Item GetItemByName(string itemName)
    {
        return itemList.FirstOrDefault(item => item.itemName == itemName);
    }
}
