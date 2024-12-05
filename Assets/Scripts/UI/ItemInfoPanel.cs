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

    public void ShowInfo(Item _item)
    {
        itemIcon.sprite = _item.itemImage;
        itemTextName.text = _item.itemName;
        itemTextCnt.text = _item.itemCnt.ToString();
    }
}
