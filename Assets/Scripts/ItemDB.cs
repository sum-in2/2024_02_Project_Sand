using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public static ItemDB instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject usingItemsPrefab;
    public Vector3[] Pos;

    public List<Item> itemList = new List<Item>();

    private void Start()
    {

    }
}
