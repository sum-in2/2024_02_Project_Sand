using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighPriceList : MonoBehaviour
{
    private List<GameObject> images = new List<GameObject>();
    public List<Item> items = new List<Item>();
    public CountryItems country;

    private void Start()
    {
        items = country.GetHighPriceItems((Difficulty)1);
        for (int i = 0; i < 5; i++)
        {
            images.Add(transform.GetChild(i).gameObject);
            images[i].GetComponent<SpriteRenderer>().sprite = items[i].itemImage;
        }
    }
}
