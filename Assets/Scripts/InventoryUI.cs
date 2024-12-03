using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;

    public Slot[] slots;
    public Transform slotHolder;

    private void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.SlotCount = slots.Length;
        inven.onChangeItem += RedrawInvetoryUI;
        RedrawInvetoryUI();
    }

    private void RedrawInvetoryUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlots();
        }
        for (int i = 0; i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();
        }
    }
}
