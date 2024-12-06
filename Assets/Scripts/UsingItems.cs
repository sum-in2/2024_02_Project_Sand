using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingItems : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;

    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemValue = _item.itemValue;

        image.sprite = _item.itemImage;
    }

    public void DestoryItem()
    {
        Destroy(gameObject);
    }
}