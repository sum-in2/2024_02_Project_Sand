using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using UnityEngine;

public class Countries : MonoBehaviour
{
    public GameObject[] gameObjects;
    public Point[] countriesPos;

    private void Awake()
    {
        gameObjects = new GameObject[transform.childCount];
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i] = transform.GetChild(i).gameObject;
            gameObjects[i].gameObject.name = ((Country)i).ToString();
        }
    }
}
