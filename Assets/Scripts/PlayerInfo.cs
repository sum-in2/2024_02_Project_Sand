using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// TODO : 현재 위치중인 도시, 돈, 레벨, 경험치 등
public class PlayerInfo : MonoBehaviour
{
    public string nowInCountry;
    int level;
    int exp;
    int money;
    int men;
    int combat;
    int camel;
    private void Awake()
    {
        level = 4;
        exp = 26150;
        money = 26150;
        men = 5;
        combat = 6;
        camel = 4;
    }

    public int[] getInfo()
    {
        return new int[5] { level, money, men, combat, camel };
    }
    void Update()
    {

    }
}
