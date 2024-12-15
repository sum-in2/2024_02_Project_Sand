using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeUI : MonoBehaviour
{
    Inventory inven;
    TraderInfo traderItems;
    public TraderInfo TraderItems
    {
        get { return traderItems; }
        set { traderItems = value; }
    }

    public List<Item> countryItems;

    [HideInInspector] public Slot[] exchangePlayerSlots;
    [HideInInspector] public Slot[] exchangeShopSlots;
    [HideInInspector] public Slot[] cellPlayerSlots;
    [HideInInspector] public Slot[] cellShopSlots;
    public Transform exchangePlayerSlotHolder;
    public Transform exchangeShopSlotHolder;
    public Transform cellPlayerSlotHolder;
    public Transform cellShopSlotHolder;

    public TextMeshProUGUI cellPricePlayer;
    public TextMeshProUGUI cellPriceTrader;

    [Header("Scale")]

    [SerializeField] List<Sprite> scaleImages = new List<Sprite>();
    [SerializeField] GameObject scaleObject;

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
        cellPricePlayer.text = CalculateValue(inven.exchangeItems).ToString();

        UpdateSlots(exchangeShopSlots, countryItems);
        UpdateSlots(cellShopSlots, traderItems.items);
        cellPriceTrader.text = CalculateValue(traderItems.items).ToString();

        SettingScale();
    }

    void SettingScale()
    {
        Image imageObject = scaleObject.GetComponent<Image>();
        if (int.TryParse(cellPriceTrader.text, out int trader) &&
            int.TryParse(cellPricePlayer.text, out int player))
        {
            int maxValue = Mathf.Max(trader, player);
            int temp = maxValue / 2;
            int difference = player - trader;

            if (difference > temp) imageObject.sprite = scaleImages[0];
            else if (difference > 0) imageObject.sprite = scaleImages[1];
            else if (difference == 0) imageObject.sprite = scaleImages[2];
            else if (difference < 0) imageObject.sprite = scaleImages[3];
            else imageObject.sprite = scaleImages[4];
        }
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
