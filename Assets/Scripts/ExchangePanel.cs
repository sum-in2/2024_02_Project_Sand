using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExchangePanel : MonoBehaviour
{
    private Item exchangeItem;
    public UnityEngine.UI.Image itemIcon;
    public TextMeshProUGUI itemTextName;
    public TextMeshProUGUI itemTextCnt;

    public Slider itemCountSlider;
    private int maxItemCount;
    private int currentCount;

    public void ShowInfo(Item _item)
    {
        exchangeItem = new Item(_item);
        itemIcon.sprite = exchangeItem.itemImage;
        itemTextName.text = exchangeItem.itemName;
        maxItemCount = exchangeItem.itemCnt;

        itemCountSlider.minValue = 0;
        itemCountSlider.maxValue = maxItemCount;
        itemCountSlider.value = 0;
        itemTextCnt.text = "0 / " + maxItemCount.ToString();
        itemCountSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        currentCount = Mathf.RoundToInt(value);
        itemTextCnt.text = currentCount.ToString() + " / " + maxItemCount.ToString();
    }
    public void ExchangeOK()
    {
        exchangeItem.itemCnt = currentCount;
        Inventory.instance.ExchangeItems(exchangeItem);
    }
}
