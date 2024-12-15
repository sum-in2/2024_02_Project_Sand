using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ExchangeTest : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (UIManager.Instance.getUiStackPeek() == null)
        {
            // UIManager.Instance.exchangeUI.TraderInventory = GetComponent<TraderInventory>();
            // UIManager.Instance.ToggleExchangeUI();

            CountryItems countryItems = GetComponent<CountryItems>();
            List<Item> itemsWithDifficulty = countryItems.itemsWithDifficulty;
            Difficulty difficulty = countryItems.difficulty;
            string countryName = countryItems.CountryName;

            UIManager.Instance.OpenTraderInCountry(itemsWithDifficulty, difficulty, countryName);
        }
    }
}
