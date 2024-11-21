using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ItemInfoPanel : MonoBehaviour
{
    public UnityEngine.UI.Image itemIcon;
    public TextMeshProUGUI itemTextName;
    public TextMeshProUGUI itemTextCnt;

    public Slider itemCountSlider;
    private int maxItemCount;

    public void ShowInfo(Item _item)
    {
        itemIcon.sprite = _item.itemImage;
        itemTextName.text = _item.itemName;

        maxItemCount = _item.itemCnt;
        itemCountSlider.minValue = 0;
        itemCountSlider.maxValue = maxItemCount;
        itemCountSlider.value = 0;
        itemTextCnt.text = "0 / " + maxItemCount.ToString();
        itemCountSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        int currentCount = Mathf.RoundToInt(value);
        itemTextCnt.text = currentCount.ToString() + " / " + maxItemCount.ToString();
    }
}
