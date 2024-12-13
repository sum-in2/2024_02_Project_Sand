using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangePriceObject : MonoBehaviour
{
    [SerializeField] Image arrowImage;
    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI itemValue;

    public void InitData(Item item, Price price)
    {
        string arrow = price switch
        {
            Price.Decrease => "arrow-down",
            Price.Increase => "arrow-up",
            _ => "null"
        };

        arrowImage.sprite = Resources.Load<Sprite>($"Public/{arrow}");
        itemValue.text = item.itemValue.ToString();
        itemImage.sprite = item.itemImage;
    }
}
