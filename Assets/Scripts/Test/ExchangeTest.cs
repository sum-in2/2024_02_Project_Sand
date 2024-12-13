using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeTest : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (UIManager.Instance.getUiStackPeek() == null)
        {
            UIManager.Instance.exchangeUI.TraderInventory = GetComponent<TraderInventory>();
            UIManager.Instance.ToggleExchangeUI();
        }
    }
}
