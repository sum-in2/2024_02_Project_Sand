using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TraderDB : MonoBehaviour
{
    #region Singleton

    public static TraderDB instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        traderDB = DataManager.instance.LoadTraderCSV("traderDB");
    }
    #endregion

    public Dictionary<(Country, Difficulty), List<Trader>> traderDB = new Dictionary<(Country, Difficulty), List<Trader>>();
}