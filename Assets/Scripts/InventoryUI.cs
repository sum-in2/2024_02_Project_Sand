using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool activelnventory = false;

    public Slot[] slots;
    public Transform slotHolder;

    private void Start()
    {
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inventoryPanel.SetActive(activelnventory);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activelnventory = !activelnventory;
            inventoryPanel.SetActive(activelnventory);
        }
    }
}
