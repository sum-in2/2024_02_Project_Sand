using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountryInMap : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public SpriteRenderer spriteRenderer;
    public Sprite camel;
    public Sprite castle;
    public TextMeshPro countryName;

    void Start()
    {
        countryName.text = gameObject.name;
        if (gameObject.name == playerInfo.nowInCountry)
            spriteRenderer.sprite = camel;
        else
            spriteRenderer.sprite = castle;
    }
}
