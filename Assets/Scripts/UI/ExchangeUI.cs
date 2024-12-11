using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class ExchangeUI : MonoBehaviour
{
    Inventory inven;
    TraderInventory traderInventory;
    public TraderInventory TraderInventory
    {
        get { return traderInventory; }
        set { traderInventory = value; }
    }

    public Slot[] exchangePlayerSlots;
    public Slot[] exchangeShopSlots;
    public Slot[] cellPlayerSlots;
    public Slot[] cellShopSlots;
    public Transform exchangePlayerSlotHolder;
    public Transform exchangeShopSlotHolder;
    public Transform cellPlayerSlotHolder;
    public Transform cellShopSlotHolder;

    public TextMeshProUGUI cellPricePlayer;
    public TextMeshProUGUI cellPriceTrader;

    private void Start()
    {
        inven = Inventory.instance;

        exchangePlayerSlots = exchangePlayerSlotHolder.GetComponentsInChildren<Slot>();
        cellPlayerSlots = cellPlayerSlotHolder.GetComponentsInChildren<Slot>();

        exchangeShopSlots = exchangeShopSlotHolder.GetComponentsInChildren<Slot>();
        cellShopSlots = cellShopSlotHolder.GetComponentsInChildren<Slot>();

        inven.SlotCount = exchangePlayerSlots.Length;
        inven.onChangeExc += RedrawExchangeUI;
        RedrawExchangeUI();
    }

    void UpdateSlots(Slot[] slots, List<Item> items)
    {
        int count = Mathf.Min(slots.Length, items.Count);

        for (int i = 0; i < count; i++)
        {
            slots[i].RemoveSlots();
            slots[i].item = items[i];
            slots[i].UpdateSlotUI();
        }
        for (int i = count; i < slots.Length; i++)
        {
            slots[i].RemoveSlots();
        }
    }

    private void RedrawExchangeUI()
    {
        UpdateSlots(exchangePlayerSlots, inven.items);
        UpdateSlots(cellPlayerSlots, inven.exchangeItems);
        UpdateSlots(exchangeShopSlots, traderInventory.traderItem);
        UpdateSlots(cellShopSlots, traderInventory.traderExchange);

        cellPricePlayer.text = CalculateValue(inven.exchangeItems).ToString();
        cellPriceTrader.text = CalculateValue(traderInventory.traderExchange).ToString();
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
        inven.ExchangeCancel();
    }
}
