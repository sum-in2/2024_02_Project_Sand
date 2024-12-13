using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CountryBtn : MonoBehaviour
{
    HighPriceList highPriceList;
    TraderInventory traderInventory;

    private void OnMouseDown()
    {
        if (UIManager.Instance.getUiStackPeek() == null)
        {
            traderInventory = gameObject.GetComponentInParent<TraderInventory>();

            UIManager.Instance.exchangeUI.TraderInventory = traderInventory;
            UIManager.Instance.OpenCountryInfo(traderInventory);
        }
    }
}