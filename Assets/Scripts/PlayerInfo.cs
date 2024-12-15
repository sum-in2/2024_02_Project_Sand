using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// TODO : 현재 위치중인 도시, 돈, 레벨, 경험치 등
public class PlayerInfo : MonoBehaviour
{
    public string nowInCountry;
    string playerName;
    int level;
    int exp;
    int money;
    int men;
    int combat;
    int camel;
    private void Awake()
    {
        level = 1;
        exp = 0;
        money = Inventory.instance.GetPlayerMoney();
        men = 0;
        combat = 0;
        camel = 1;
    }

    public int[] getInfo()
    {
        return new int[5] { level, money, men, combat, camel };
    }
    void Update()
    {

    }
}
