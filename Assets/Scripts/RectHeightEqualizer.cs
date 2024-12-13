using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.EventSystems;

public class RectHeightEqualizer : UIBehaviour
{
    public RectTransform parentTransform;

    protected override void OnRectTransformDimensionsChange()
    {
        parentTransform.sizeDelta = new Vector2(
            parentTransform.sizeDelta.x,
            GetComponent<RectTransform>().sizeDelta.y
        );
    }
}