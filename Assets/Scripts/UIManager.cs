using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public ItemInfoPanel itemInfoPanel;
    public InventoryUI inventoryUI;

    private Stack<GameObject> uiStack = new Stack<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        inventoryUI.gameObject.SetActive(false);
        itemInfoPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (uiStack.Count != 0 && uiStack.Peek() == inventoryUI.gameObject)
                CloseUI();
            else
                OpenUI(inventoryUI.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && uiStack.Count != 0)
            CloseUI();
    }

    public void ShowItemInfo(Item item)
    {
        if (item != null && itemInfoPanel != null)
        {
            OpenUI(itemInfoPanel.gameObject);
            itemInfoPanel.ShowInfo(item);
        }
    }

    public void OpenUI(GameObject uiPanel)
    {
        if (!uiStack.Contains(uiPanel))
        {
            uiPanel.SetActive(true);
            uiStack.Push(uiPanel);
        }
    }

    public void CloseUI()
    {
        if (uiStack.Count > 0)
        {
            GameObject currentUI = uiStack.Pop();
            currentUI.SetActive(false);
        }
    }
}