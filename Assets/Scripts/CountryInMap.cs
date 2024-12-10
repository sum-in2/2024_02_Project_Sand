using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//TODO : 플레이어 위치 따라서 성 모양 / 낙타 모양 스위칭
public class CountryInMap : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public SpriteRenderer spriteRenderer;
    public Sprite camel;
    public Sprite castle;
    public TextMeshPro[] countryName;

    void Start()
    {
        countryName[0].text = gameObject.name;
        if (gameObject.name == playerInfo.nowInCountry)
            spriteRenderer.sprite = camel;
        else
            spriteRenderer.sprite = castle;
    }
}
