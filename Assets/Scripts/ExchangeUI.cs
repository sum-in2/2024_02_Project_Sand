using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class ExchangeUI : MonoBehaviour
{
    Inventory inven;

    public Slot[] exchangePlayerSlots;
    public Slot[] exchangeShopSlots;
    public Slot[] cellPlayerSlots;
    public Transform exchangePlayerSlotHolder;
    public Transform exchangeShopSlotHolder;
    public Transform cellPlayerSlotHolder;

    public TextMeshProUGUI cellPricePlayer;

    private void Start()
    {
        inven = Inventory.instance;

        exchangePlayerSlots = exchangePlayerSlotHolder.GetComponentsInChildren<Slot>();
        exchangeShopSlots = exchangeShopSlotHolder.GetComponentsInChildren<Slot>();
        cellPlayerSlots = cellPlayerSlotHolder.GetComponentsInChildren<Slot>();

        inven.SlotCount = exchangePlayerSlots.Length;
        inven.onChangeExc += RedrawExchangeUI;
        RedrawExchangeUI();
    }
    private void RedrawExchangeUI()
    {
        for (int i = 0; i < exchangePlayerSlots.Length; i++)
        {
            exchangePlayerSlots[i].RemoveSlots();
            exchangeShopSlots[i].RemoveSlots();
        }
        for (int i = 0; i < cellPlayerSlots.Length; i++)
        {
            cellPlayerSlots[i].RemoveSlots();
        }
        for (int i = 0; i < inven.items.Count; i++)
        {
            // TODO: 물자 DB, 상인 DB 연동시키기
            exchangePlayerSlots[i].item = inven.items[i];
            exchangePlayerSlots[i].UpdateSlotUI();
        }
        for (int i = 0; i < inven.exchangeItems.Count; i++)
        {
            cellPlayerSlots[i].item = inven.exchangeItems[i];
            cellPlayerSlots[i].UpdateSlotUI();
        }

        cellPricePlayer.text = CalculateValue(inven.exchangeItems).ToString();
    }

    private int CalculateValue(List<Item> _items)
    {
        int temp = 0;

        foreach (Item item in _items)
        {
            temp += item.itemValue * item.itemCnt;
        }
        return temp;
    }
    public void ExchangeCancel()
    {
        foreach (Item item in inven.exchangeItems)
        {
            foreach (Item _item in inven.items)
            {
                if (item.itemName == _item.itemName)
                {
                    _item.itemCnt += item.itemCnt;
                    break;
                }
            }
        }
        inven.exchangeItems.Clear();
    }
}
