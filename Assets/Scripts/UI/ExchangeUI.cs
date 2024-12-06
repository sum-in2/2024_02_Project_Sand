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
        traderInventory = TraderInventory.instance;
        inven = Inventory.instance;

        exchangePlayerSlots = exchangePlayerSlotHolder.GetComponentsInChildren<Slot>();
        cellPlayerSlots = cellPlayerSlotHolder.GetComponentsInChildren<Slot>();

        exchangeShopSlots = exchangeShopSlotHolder.GetComponentsInChildren<Slot>();
        cellShopSlots = cellShopSlotHolder.GetComponentsInChildren<Slot>();

        inven.SlotCount = exchangePlayerSlots.Length;
        inven.onChangeExc += RedrawExchangeUI;
        RedrawExchangeUI();
    }
    private void OnEnable()
    {
        traderInventory.InitList((Country)3, 2);
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
            cellShopSlots[i].RemoveSlots();
        }
        for (int i = 0; i < inven.items.Count; i++)
        {
            exchangePlayerSlots[i].item = inven.items[i];
            exchangePlayerSlots[i].UpdateSlotUI();
        }
        for (int i = 0; i < inven.exchangeItems.Count; i++)
        {
            cellPlayerSlots[i].item = inven.exchangeItems[i];
            cellPlayerSlots[i].UpdateSlotUI();
        }
        for (int i = 0; i < traderInventory.traderItem.Count; i++)
        {
            exchangeShopSlots[i].item = traderInventory.traderItem[i];
            exchangeShopSlots[i].UpdateSlotUI();
        }
        for (int i = 0; i < traderInventory.traderExchange.Count; i++)
        {
            cellShopSlots[i].item = traderInventory.traderExchange[i];
            cellShopSlots[i].UpdateSlotUI();
        }

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
