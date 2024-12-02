using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invetory : MonoBehaviour
{
    #region Singleton
    public static Invetory instance;
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
        if (items.Count > 0)
        {
            foreach (Item item in items)
            {
                if (item.itemName == _item.itemName)
                {
                    item.itemCnt += _item.itemCnt;
                    if (onChangeItem != null)
                        onChangeItem.Invoke();
                    return true;
                }
            }
        }
        if (items.Count < slotCnt)
        {
            items.Add(new Item(_item));
            if (onChangeItem != null)
                onChangeItem.Invoke();
            return true;
        }
        return false;
    }

    public bool ExchangeItems(Item _item)
    {
        foreach (Item item in items)
        {
            if (item.itemName == _item.itemName)
            {
                //TODO : 교환 실패 후 창 닫으면 다시 돌려줘야함
                item.itemCnt -= _item.itemCnt;
            }
        }
        exchangeItems.Add(new Item(_item));

        return false;
    }
}