using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//TODO : 버튼 누르면 상점 초기화
// 부모의 traderinventory 컴포넌트를 exchangeui에 입력해야함.
// uimanager instance traderinventory = 부모 traderinventory
// uimanager instance excuiswitch
public class CountryBtn : MonoBehaviour
{

    TraderInventory traderInventory;
    private Vector3 dragOrigin;

    private void Update()
    {
    }

    private void OnMouseDown()
    {
        if (UIManager.Instance.getUiStackPeek() == null)
        {
            if (traderInventory == null)
            {
                traderInventory = gameObject.GetComponentInParent<TraderInventory>();
            }
            UIManager.Instance.exchangeUI.TraderInventory = traderInventory;
            UIManager.Instance.ToggleExchangeUI();
        }
    }
}
