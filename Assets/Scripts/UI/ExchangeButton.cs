using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeButton : MonoBehaviour
{
    public ExchangePanel exchangePanel;
    public void onClickExchangeOK()
    {
        exchangePanel.ExchangeOK();
    }
}
