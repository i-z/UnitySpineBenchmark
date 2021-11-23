using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLayoutActivator : MonoBehaviour {
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private int _columns;
    [SerializeField]
    private int _count;
    [SerializeField]
    private Vector2 _objectSize;


    public void Populate() {
        Clean();
        for (int i = 0; i < _count; i++) {
            var c = Instantiate(_prefab, transform);
            int row = i / _columns;
            var pos = new Vector3();
            pos.x = (i - (_columns * row)) * _objectSize.x;
            pos.y = -row * _objectSize.y;
            c.transform.localPosition  = pos;
        }
    }

    public void Clean() {
        List<GameObject> todelete = new List<GameObject>();
        foreach (var c in gameObject.transform) {
            todelete.Add(((Transform)c).gameObject);
        }
        todelete.ForEach(x => DestroyImmediate(x));
    }
}
