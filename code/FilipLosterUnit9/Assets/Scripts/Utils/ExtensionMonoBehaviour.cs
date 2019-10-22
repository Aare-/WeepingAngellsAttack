using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class ExtensionMonoBehaviour {
    public static GameObject GetGameObjectSafelly(this MonoBehaviour m, string path) {
        var t = m.transform.Find(path);
        if (t == null)
            throw new System.ArgumentException("Child not found", path);
        return t.gameObject;
    }

    public static GameObject GetFirstGameObjectStartingWithNameSafelly(this MonoBehaviour m, string prefix) {
        for (var i = 0; i < m.transform.childCount; i++) {
            var t = m.transform.GetChild(i);
            if (t.name.StartsWith(prefix))
                return t.gameObject;
        }

        throw new System.ArgumentException("Child not found", prefix);
    }

    public static List<GameObject> GetFirstGameObjectsStartingWithNameSafelly(this MonoBehaviour m, string prefix) {
        var list = new List<GameObject>();
        for (var i = 0; i < m.transform.childCount; i++) {
            var t = m.transform.GetChild(i);
            if (t.name.StartsWith(prefix))
                list.Add(t.gameObject);
        }
        
        return list;
    }

    public static string GetPath(this Transform t, GameObject terminateGO = null) {
        var result = t.name;
        t = t.parent;
        while (t.gameObject != terminateGO) {
            result = String.Format("{0}/{1}", t.name, result);
            t = t.parent;
        }

        return result;
    }

    public static T GetInParent<T>(this Transform t) {        
        var comp = default(T);

        do {
            t = t.parent;
            comp = t.gameObject.GetComponent<T>();            
        } while (comp == null && t.parent != null);
        
        return comp;
    }
}
