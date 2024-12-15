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
        itemList = DataManager.instance.LoadItemCSV("ItemDB");
    }
    #endregion

    public List<Item> itemList = new List<Item>();

    public Item GetItemByName(string itemName)
    {
        return itemList.FirstOrDefault(item => item.itemName == itemName);
    }
}
