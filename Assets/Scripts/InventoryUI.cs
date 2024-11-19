using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryUI : MonoBehaviour
{
    Invetory inven;
    public GameObject inventoryPanel;
    bool activelnventory = false;

    public Slot[] slots;
    public Transform slotHolder;

    private void Start()
    {
        inven = Invetory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inventoryPanel.SetActive(activelnventory);
        inven.SlotCount = slots.Length;
        inven.onChangeItem += RedrawInvetoryUI;
        RedrawInvetoryUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activelnventory = !activelnventory;
            inventoryPanel.SetActive(activelnventory);
        }
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
