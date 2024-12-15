using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public enum Country
{
    Samarkand,
    Merv,
    Nishaqur,
    Gorgan,
    Ecbatana,
    Baghdad,
    Ezurum,
    Palmyra,
    Antioch,
    Damascus,
    Jerusalem,
    Alexandria,
}

public class DataManager : MonoBehaviour
{
    #region Singleton
    public static DataManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    string[] OpenCSVData(string _CSVFileName)
    {
        TextAsset csvData = Resources.Load<TextAsset>($"DB/{_CSVFileName}");
        if (csvData == null)
            return null;

        return csvData.text.Split(new char[] { '\n' });
    }

    public Dictionary<(Country, Difficulty), List<Item>> LoadCountryCSV(string _CSVFileName)
    {
        Dictionary<(Country, Difficulty), List<Item>> res = new Dictionary<(Country, Difficulty), List<Item>>();

        string[] data = OpenCSVData(_CSVFileName);
        if (data == null) return null;

        for (int i = 1; i < data.Length; i++)
        {
            string[] element = data[i].Split(new char[] { ',' });
            if (Enum.TryParse<Country>(element[0], out Country country) &&
                Enum.TryParse<Difficulty>(element[2], out Difficulty difficulty))
            {
                var key = (country, difficulty);
                if (!res.ContainsKey(key))
                {
                    res[key] = new List<Item>();
                }

                Sprite sprite = Resources.Load<Sprite>($"ItemImage/{element[1]}");
                res[key].Add(new Item(
                    sprite,
                    element[1],
                    int.Parse(element[3]),
                    int.Parse(element[4])
                ));
            }
        }

        return res;
    }

    public List<Item> LoadItemCSV(string _CSVFileName)
    {
        List<Item> res = new List<Item>();

        string[] data = OpenCSVData(_CSVFileName);
        if (data == null) return null;

        for (int i = 1; i < data.Length; i++)
        {
            string[] element = data[i].Split(new char[] { ',' });

            Sprite sprite = Resources.Load<Sprite>($"ItemImage/{element[0]}");
            res.Add(new Item(
                sprite,
                element[0],
                int.Parse(element[1]),
                int.Parse(element[2])
            ));
        }

        return res;
    }

    public Dictionary<(Country, Difficulty), List<Trader>> LoadTraderCSV(string _CSVFileName)
    {
        Dictionary<(Country, Difficulty), List<Trader>> items = new Dictionary<(Country, Difficulty), List<Trader>>();
        string[] data = OpenCSVData(_CSVFileName);
        if (data == null) return null;

        for (int i = 1; i < data.Length; i++)
        {
            string[] element = data[i].Split(new char[] { ',' });
            // 0 = Country, 1 = Level, 2 = TraderName, 3 = Difficulty, 4 = ItemName, 5 = ItemCount
            if (Enum.TryParse<Country>(element[0], out Country country) &&
                Enum.TryParse<Difficulty>(element[3], out Difficulty difficulty) &&
                int.TryParse(element[1][3].ToString(), out int level) &&
                int.TryParse(element[5], out int itemCount))
            {
                var tuple = (country, difficulty);
                if (!items.ContainsKey(tuple))
                {
                    items[tuple] = new List<Trader>();
                }
                items[tuple].Add(new Trader(level, element[2], element[4], itemCount));
            }

        }
        return items;
    }
}