using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CountryBtn : MonoBehaviour
{
    CountryItems countryItems;

    private void OnMouseDown()
    {
        if (UIManager.Instance.getUiStackPeek() == null)
        {
            countryItems = gameObject.GetComponentInParent<CountryItems>();
            UIManager.Instance.OpenCountryInfo(countryItems);
        }
    }
}