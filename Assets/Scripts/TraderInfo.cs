using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class TraderInfo : MonoBehaviour
{
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textLevel;
    public TextMeshProUGUI textMoney;
    string traderName;
    int level;
    public List<Item> items = new List<Item>();

    // TODO : Onclick 이름,

    public void InitTrader((string, int) tuple, List<Item> _items)
    {
        traderName = tuple.Item1;
        level = tuple.Item2;
        items = _items;


        textName.text = traderName;
        textLevel.text = level.ToString();
        textMoney.text = GetItemTotalPrice().ToString();
    }

    public int GetItemTotalPrice()
    {
        int temp = 0;

        foreach (Item item in items)
        {
            temp += item.itemValue * item.itemCnt;
        }

        return temp;
    }

    public void OnClick()
    {
        UIManager.Instance.exchangeUI.TraderItems = GetComponent<TraderInfo>();
        UIManager.Instance.ToggleExchangeUI();
    }
}
