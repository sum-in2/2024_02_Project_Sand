using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountryInfo : MonoBehaviour
{
    [HideInInspector] public TraderInventory traderInventory;
    List<Item> items = new List<Item>();
    [SerializeField] List<GameObject> images = new List<GameObject>();
    [SerializeField] TextMeshProUGUI countryName;
    [SerializeField] List<GameObject> dataList = new List<GameObject>();

    //TODO : 플레이어 인벤토리 저장???? 싱글톤에서 복사해서 traderinventory랑 비교 후
    // dictionary가 나을듯 <int, List<Item>>
    // 분류 끝나면 각 홀더 자식으로 Instantiate

    void OnEnable()
    {
        items = traderInventory.GetHighPriceItems();
        for (int i = 0; i < items.Count; i++)
            images[i].gameObject.GetComponent<Image>().sprite = items[i].itemImage;

        countryName.text = traderInventory.CountryName;
    }
}
