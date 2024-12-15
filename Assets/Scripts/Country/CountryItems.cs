using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CountryItems : MonoBehaviour
{
    string countryName;
    public string CountryName { get { return countryName; } set { } }
    public Dictionary<Difficulty, List<Item>> countryItems = new Dictionary<Difficulty, List<Item>>();
    public List<Item> highPriceItems = new List<Item>();
    public List<Item> itemsWithDifficulty = new List<Item>();
    public Difficulty difficulty;

    private void Awake()
    {

        InitItems();
        difficulty = GetRandomDifficulty();
        itemsWithDifficulty = GetItemsWithDifficulty();
    }

    List<Item> GetItemsWithDifficulty()
    {
        return new List<Item>(countryItems[difficulty]);
    }

    Difficulty GetRandomDifficulty()
    {
        float randomValue = Random.value; // 0.0에서 1.0 사이의 랜덤 값

        if (randomValue < 0.3f)
            return Difficulty.low;
        else if (randomValue < 0.7f)
            return Difficulty.mid;
        else
            return Difficulty.high;
    }


    public void InitItems()
    {
        countryName = gameObject.name;
        for (int i = 0; i < System.Enum.GetValues(typeof(Difficulty)).Length; i++)
        {
            countryItems[(Difficulty)i] = CountryDB.instance.GetItemsInCountryDifficulty(countryName, (Difficulty)i);
        }
    }

    public List<Item> GetHighPriceItems(Difficulty difficulty)
    {
        return countryItems[difficulty].OrderByDescending(x => x.itemValue).Take(7).ToList(); ;
    }
}
