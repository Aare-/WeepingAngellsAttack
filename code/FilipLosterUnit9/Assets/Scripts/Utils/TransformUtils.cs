using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public static class TransformUtils {
    public static String GetFullPath(this Transform transform) {
        var result = "";

        while (transform != null) {
            result = transform.name + "/" + result;
            transform = transform.parent;
        }

        return result;
    }

    public static T GetFirstFromParent<T>(this Transform transform) where T : MonoBehaviour {
        var t = transform;
        do {            
            if (t == null) return default(T);

            var result = t.GetComponent<T>();            

            if (result != null)
                return result;
            
            t = t.parent;
        } while (true);        
    }
    
}
