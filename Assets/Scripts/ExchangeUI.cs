using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeUI : MonoBehaviour
{
    Invetory inven;

    public Slot[] exchangePlayerSlots;
    public Slot[] exchangeShopSlots;
    public Transform exchangePlayerSlotHolder;
    public Transform exchangeShopSlotHolder;

    private void Start()
    {
        inven = Invetory.instance;

        exchangePlayerSlots = exchangePlayerSlotHolder.GetComponentsInChildren<Slot>();
        exchangeShopSlots = exchangeShopSlotHolder.GetComponentsInChildren<Slot>();

        inven.SlotCount = exchangePlayerSlots.Length;
        RedrawInvetoryUI();
    }

    // TODO: Redraw 호출
    private void RedrawInvetoryUI()
    {
        for (int i = 0; i < exchangePlayerSlots.Length; i++)
        {
            exchangePlayerSlots[i].RemoveSlots();
        }
        for (int i = 0; i < exchangeShopSlots.Length; i++)
        {
            exchangeShopSlots[i].RemoveSlots();
        }
        for (int i = 0; i < inven.items.Count; i++)
        {
            // TODO: 물자 DB, 상인 DB 연동시키기
            exchangePlayerSlots[i].item = inven.items[i];
            exchangePlayerSlots[i].UpdateSlotUI();
        }
    }
}
