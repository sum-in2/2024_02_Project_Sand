using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TestItemAdd : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();

    public void OnClickTestAdd()
    {
        if (itemList != ItemDB.instance.itemList)
        {
            itemList = ItemDB.instance.itemList;
        }
        Inventory.instance.AddItem(itemList[Random.Range(0, 3)]);
    }
}
