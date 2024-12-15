using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        Inventory.instance.PlayerStartItemSetting();
    }
    #endregion

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;
    public delegate void OnChangeExc();
    public OnChangeExc onChangeExc;
    private int slotCnt;
    public int SlotCount
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
        }
    }

    public List<Item> items = new List<Item>();
    public List<Item> exchangeItems = new List<Item>();

    public bool AddItem(Item _item)
    {
        if (AddItem(_item, items))
        {
            if (onChangeItem != null)
                onChangeItem.Invoke();
            return true;
        }
        return false;
    }

    public int GetPlayerMoney()
    {
        int i = 0;
        foreach (Item item in items)
        {
            i += item.itemValue * item.itemCnt;
        }
        return i;
    }

    public bool ExchangeItems(Item _item)
    {
        if (AddItem(_item, exchangeItems))
        {
            bool bCheck = false;
            foreach (Item item in items)
            {
                if (item.itemName == _item.itemName)
                {
                    item.itemCnt -= _item.itemCnt;
                    bCheck = true;
                    break;
                }
            }
            if (bCheck)
            {
                if (onChangeExc != null)
                    onChangeExc.Invoke();
                return true;
            }
        }

        return false;
    }

    private bool AddItem(Item _item, List<Item> _items)
    {
        if (_items.Count > 0)
        {
            foreach (Item item in _items)
            {
                if (item.itemName == _item.itemName)
                {
                    item.itemCnt += _item.itemCnt;
                    return true;
                }
            }
        }
        if (_items.Count < slotCnt)
        {
            _items.Add(new Item(_item));
            return true;
        }
        return false;
    }

    public void ExchangeCancel()
    {
        foreach (Item item in exchangeItems)
        {
            foreach (Item _item in items)
            {
                if (item.itemName == _item.itemName)
                {
                    _item.itemCnt += item.itemCnt;
                    break;
                }
            }
        }
        exchangeItems.Clear();
    }

    public void PlayerStartItemSetting()
    {
        // 진입 시 물자 ‘spices*40’, ‘books*5’, ‘tea*15’ 획득
        var temp = ItemDB.instance.itemList.ToDictionary(item => item.itemName);

        items.Add(new Item(temp["Spices"], 40));
        items.Add(new Item(temp["Books"], 5));
        items.Add(new Item(temp["Tea"], 15));
    }
}