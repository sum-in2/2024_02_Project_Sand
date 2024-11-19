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

    public bool AddItem(Item _item)
    {
        Debug.Log("호출" + _item.itemName);
        if (items.Count > 0)
        {
            foreach (Item item in items)
            {
                if (item.itemName == _item.itemName)
                {
                    item.itemCnt += _item.itemCnt;
                    //onChangeItem.Invoke();
                    return true;
                }
            }
        }
        Debug.Log("동일아이템없음");
        if (items.Count < slotCnt)
        {
            items.Add(new Item(_item));
            //onChangeItem.Invoke();
            Debug.Log("추가 성공");
            return true;
        }
        Debug.Log("추가 실패" + _item.itemName);
        return false;
    }
}