using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExchangeInfo : MonoBehaviour
{
    string playerName;
    string traderName;
    string playerMoney;
    string traderMoney;
    string playerLevel;
    string traderLevel;

    [Header("[이름, 자산, 레벨(신용)]")]
    public List<TextMeshProUGUI> player = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> trader = new List<TextMeshProUGUI>();
}
