using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public Item item;
    public UnityEngine.UI.Image itemIcon;
    public TextMeshProUGUI itemCountText;

    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        itemCountText.text = item.itemCnt.ToString();
        itemIcon.gameObject.SetActive(true);
        itemCountText.gameObject.SetActive(true);
    }
    public void RemoveSlots()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
        itemCountText.gameObject.SetActive(false);
    }

    public void OnSlotClick()
    {
        if (item != null)
        {
            UIManager.Instance.ShowItemInfo(item);
        }
    }
    public void OnExchangeClick()
    {
        if (item != null)
        {
            UIManager.Instance.ShowExchange(item);
        }
    }
}
