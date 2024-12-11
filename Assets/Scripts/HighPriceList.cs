using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighPriceList : MonoBehaviour
{
    public TraderInventory traderInventory;
    [SerializeField]
    private List<GameObject> images = new List<GameObject>();
    public List<Item> items = new List<Item>();

    private void Start()
    {
        items = traderInventory.GetHighPriceItems();
        for (int i = 0; i < 5; i++)
        {
            images.Add(transform.GetChild(i).gameObject);
            images[i].GetComponent<SpriteRenderer>().sprite = items[i].itemImage;
        }
    }
}
