using System.Collections;
using System.Collections.Generic;
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

    public bool ExchangeItems(Item _item)
    {
        // TODO : 교환 실패 후 창 닫으면 다시 돌려줘야함
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
}