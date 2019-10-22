using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Reflection;

public static class GameObjectExtensions {
    private static string[] _SortingLayers;

    public static void RemoveAllChildren(this GameObject obj, Func<GameObject, bool> filter = null) {
        var childs = obj.transform.childCount;
        for (var i = childs; i > 0; i--) {
            if (filter != null && !filter(obj.transform.GetChild(i - 1).gameObject)) continue;
            GameObject.DestroyImmediate(obj.transform.GetChild(i - 1).gameObject);
        }
    }

    public static void RemoveAllChildrenNotImmediate(this GameObject obj) {
        var childs = obj.transform.childCount;
        for (var i = childs; i > 0; i--)
            GameObject.Destroy(obj.transform.GetChild(i - 1).gameObject);
    } 

    // Source: http://answers.unity3d.com/questions/530178/how-to-get-a-component-from-an-object-and-add-it-t.html
    public static T AddComponentCopy<T>(this GameObject go, T component) where T : Component {
        Component newComponent = go.AddComponent<T>();
        var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
        var type = component.GetType();
        var pinfos = typeof(T).GetProperties(flags);

        foreach (var pinfo in pinfos) {
            if (pinfo.CanWrite) {
                try {
                    pinfo.SetValue(newComponent, pinfo.GetValue(component, null), null);
                }
                catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
            }
        }
        
        var finfos = type.GetFields(flags);
        foreach (var finfo in finfos) {
            finfo.SetValue(newComponent, finfo.GetValue(component));
        }

        return newComponent as T;
    }

    public static void ChangeSortingLayerRecursive(this GameObject root, int layer) {
        root.layer = layer;

        for (var i = 0; i < root.transform.childCount; i++ )
            ChangeSortingLayerRecursive(root.transform.GetChild(i).gameObject, layer);
    }
}

