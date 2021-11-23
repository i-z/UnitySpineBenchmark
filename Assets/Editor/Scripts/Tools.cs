using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public delegate void ObjectAction(GameObject go);

public class Tools {

    [MenuItem("Tools/Disable Script Components In Selected")]
    public static void DisableScriptsInSelected() {
        var go = Selection.gameObjects;
        foreach (var g in go) {
            DisableScripts(g);
        }
    }

    private static void DisableScripts(GameObject g) {

        var components = g.GetComponents<MonoBehaviour>();
        foreach (var c in components) {
            c.enabled = false;
        }
        foreach (Transform childT in g.transform) {
            DisableScripts(childT.gameObject);
        }
    }
    static public void DoRecursively(GameObject go, ObjectAction action) {
        if (go.activeSelf) {
            action(go);
        }
        foreach (var item in go.transform) {
            var t = item as Transform;
            if (t != null) {
                DoRecursively(t.gameObject, action);
            }
        }
    }

    [MenuItem("Tools/Make Translucent")]
    public static void MakeTranslucent() {
        var go = Selection.gameObjects;
        foreach (var g in go) {
            DoRecursively(g, x => {
                SpriteRenderer sprite = null;
                if (x.TryGetComponent(out sprite)) {
                    var c = sprite.color;
                    c.a = 0.5f;
                    sprite.color = c;
                }
            });
        }
    }
    [MenuItem("Tools/Make Opaque")]
    public static void MakeOpaque() {
        var go = Selection.gameObjects;
        foreach (var g in go) {
            DoRecursively(g, x => {
                SpriteRenderer sprite = null;
                if (x.TryGetComponent(out sprite)) {
                    var c = sprite.color;
                    c.a = 1;
                    sprite.color = c;
                }
            });
        }
    }

    [MenuItem("Tools/Make Skeleton Translucent")]
    public static void MakeSkeletonTranslucent() {
        var go = Selection.gameObjects;
        foreach (var g in go) {
            SkeletonAnimation anim;
            if (g.TryGetComponent<SkeletonAnimation>(out anim)) {
                if (anim.skeleton != null) {
                    anim.skeleton.A = 0.5f;
                }
            }
        }
    }
    [MenuItem("Tools/Make Skeleton Opaque")]
    public static void MakeSkeletonOpaque() {
        var go = Selection.gameObjects;
        foreach (var g in go) {
            SkeletonAnimation anim;
            if (g.TryGetComponent<SkeletonAnimation>(out anim)) {
                if (anim.skeleton != null) {
                    anim.skeleton.A = 1;
                }
            }
        }
    }

    [MenuItem("Tools/Make Skeleton Effective")]
    public static void MakeSkeletonEffective() {
        var go = Selection.gameObjects;
        foreach (var g in go) {
            DoRecursively(g, x => {
                SkeletonAnimation anim;
                if (x.TryGetComponent(out anim)) {
                    anim.immutableTriangles = true;
                }
            });
        }
    }
}
