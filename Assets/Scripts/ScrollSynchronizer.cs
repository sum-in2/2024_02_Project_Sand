using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollSynchronizer : MonoBehaviour
{
    public GameObject mainScrollRect;
    public GameObject[] childScrollRects;

    private bool isUpdatingFromMain = false;

    private void Start()
    {
        mainScrollRect.GetComponent<ScrollRect>().onValueChanged.AddListener(OnMainScrollValueChanged);
    }

    private void OnEnable()
    {
        mainScrollRect.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
    }

    private void OnMainScrollValueChanged(Vector2 value)
    {
        if (isUpdatingFromMain) return;

        isUpdatingFromMain = true;

        foreach (var childScroll in childScrollRects)
        {
            childScroll.GetComponent<ScrollRect>().verticalNormalizedPosition = value.y;
        }
        isUpdatingFromMain = false;
    }
}

