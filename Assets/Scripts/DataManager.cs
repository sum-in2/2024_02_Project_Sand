using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public enum Country
{
    alexandria,
    antioch,
    baghdad,
    damascus,
    ecbatana,
    ezurum,
    gorgan,
    jerusalem,
    merv,
    nishaqur,
    palmyra,
    samarkand
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
}