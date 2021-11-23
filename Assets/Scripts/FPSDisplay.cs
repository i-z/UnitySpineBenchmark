using UnityEngine;
using System.Collections;

public class FPSDisplay : MonoBehaviour {
    float deltaTime = 0.0f;

    void Update() {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI() {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        var rHeight = h * 2 / 100;
        Rect rect = new Rect(0, h - rHeight, w, rHeight);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = rHeight;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0}x{1} {2:0.0} ms ({3:0.} fps)", w, h, msec, fps);
        GUI.Label(rect, text, style);
    }
}