using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Linq;

namespace Assets.Scripts {

    [CustomEditor(typeof(GridLayoutActivator))]
    class GridLayoutActivatorEditor : Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            GridLayoutActivator script = (GridLayoutActivator)target;

            if (GUILayout.Button("Populate")) {
                script.Populate();
            }

            if (GUILayout.Button("Clean")) {
                script.Clean();
            }
        }
    }
}
