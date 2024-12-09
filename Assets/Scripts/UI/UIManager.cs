using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public ItemInfoPanel itemInfoPanel;
    public InventoryUI inventoryUI;
    public ExchangeUI exchangeUI;
    public ExchangePanel exchangePanel;

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
        exchangeUI.gameObject.SetActive(false);
        exchangePanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            #region Inventory
            if (uiStack.Count != 0 && uiStack.Peek() == inventoryUI.gameObject)
                CloseUI();
            else
            {
                if (Inventory.instance.onChangeItem != null)
                    Inventory.instance.onChangeItem.Invoke();
                OpenUI(inventoryUI.gameObject);
            }
            #endregion
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            #region Exchange
            if (uiStack.Count != 0 && uiStack.Peek() == exchangeUI.gameObject)
                CloseUI();
            else
            {
                if (Inventory.instance.onChangeExc != null)
                    Inventory.instance.onChangeExc.Invoke();
                OpenUI(exchangeUI.gameObject);
            }
            #endregion
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

    public void ShowExchange(Item item)
    {
        if (item != null && exchangePanel != null)
        {
            OpenUI(exchangePanel.gameObject);
            exchangePanel.ShowInfo(item);
        }
    }

    public void OpenUI(GameObject uiPanel)
    {
        if (!uiStack.Contains(uiPanel))
        {
            uiPanel.SetActive(true);

            Canvas parentCanvas = uiPanel.transform.parent.GetComponent<Canvas>();
            if (parentCanvas != null)
            {
                parentCanvas.sortingOrder = uiStack.Count;
            }
            else
            {
                Debug.LogWarning("부모 오브젝트에 Canvas 컴포넌트가 없습니다: " + uiPanel.name);
            }

            uiStack.Push(uiPanel);
        }
    }

    public void CloseUI()
    {
        if (uiStack.Count > 0)
        {
            GameObject currentUI = uiStack.Pop();
            if (currentUI.gameObject == exchangeUI.gameObject)
                exchangeUI.GetComponent<ExchangeUI>().ExchangeCancel();

            currentUI.SetActive(false);
        }
    }
}