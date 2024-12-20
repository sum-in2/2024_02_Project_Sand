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
    public TopbarUI topbarUI;
    public CountryInfo countryInfo;
    public TraderInCountry traderInCountry;

    private Stack<GameObject> uiStack = new Stack<GameObject>();

    public delegate void OnChangePlayerInfo();
    public OnChangePlayerInfo onChangePlayerInfo;

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
        topbarUI.gameObject.SetActive(true);

        traderInCountry.gameObject.SetActive(false);
        countryInfo.gameObject.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.Escape) && uiStack.Count != 0)
            CloseUI();
    }

    public void OpenCountryInfo(CountryItems countryItems)
    {
        countryInfo.countryItems = countryItems;
        OpenUI(countryInfo.gameObject);
    }

    public void ToggleExchangeUI()
    {
        if (uiStack.Count != 0 && uiStack.Peek() == exchangeUI.gameObject)
            CloseUI();
        else
        {
            if (Inventory.instance.onChangeExc != null)
                Inventory.instance.onChangeExc.Invoke();
            OpenUI(exchangeUI.gameObject);
        }
    }

    public GameObject getUiStackPeek()
    {
        if (uiStack.Count != 0) return uiStack.Peek();
        else return null;
    }

    public void ShowItemInfo(Item item)
    {
        if (item != null && itemInfoPanel != null)
        {
            OpenUI(itemInfoPanel.gameObject);
            itemInfoPanel.ShowInfo(item);
        }
    }

    public void OpenTraderInCountry(List<Item> items, Difficulty difficulty, string countryName)
    {
        OpenUI(traderInCountry.gameObject);
        traderInCountry.InitTraders(items, difficulty, countryName);
        exchangeUI.countryItems = items;
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
                parentCanvas.sortingOrder = uiStack.Count + 1;
            }

            uiStack.Push(uiPanel);
        }
        if (uiStack.Count != 0 && uiStack.Peek() != countryInfo.gameObject)
            topbarUI.gameObject.SetActive(false);
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
        if (uiStack.Count == 0)
        {
            onChangePlayerInfo.Invoke();
            topbarUI.gameObject.SetActive(true);
        }
    }
}