
using UnityEngine;

static class ExtensionVector3 {
    public static Vector2 FromMapPos(this Vector3 v) {
        return new Vector2(v.x, v.z);
    }
}
