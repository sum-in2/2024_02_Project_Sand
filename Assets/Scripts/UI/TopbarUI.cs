using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TopbarUI : MonoBehaviour
{

    public TextMeshProUGUI trustText; // = level
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI menText;
    public TextMeshProUGUI combatText;
    public TextMeshProUGUI camelText;
    public PlayerInfo playerInfo;
    // Start is called before the first frame update

    private void Start()
    {
        UIManager.Instance.onChangePlayerInfo += RedrawTopBar;
        RedrawTopBar();
    }

    private void RedrawTopBar()
    {
        int[] infos = playerInfo.getInfo();
        TextMeshProUGUI[] texts = {
            trustText,
            moneyText,
            menText,
            combatText,
            camelText
        };

        for (int i = 0; i < infos.Length; i++)
            texts[i].text = infos[i].ToString();
    }
}