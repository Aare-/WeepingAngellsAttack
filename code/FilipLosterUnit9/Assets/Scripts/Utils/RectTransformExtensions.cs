using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public static class RectTransformExtensions {
    public static Vector3 SetPivotInPlace(this RectTransform rectTransform, Vector2 pivot) {
        if (rectTransform == null) return Vector3.zero;

        var size = rectTransform.rect.size;
        var deltaPivot = rectTransform.pivot - pivot;
        var deltaPosition = new Vector3(deltaPivot.x * size.x, deltaPivot.y * size.y);
        rectTransform.pivot = pivot;
        rectTransform.localPosition -= deltaPosition;

        return deltaPosition;
    }


}
