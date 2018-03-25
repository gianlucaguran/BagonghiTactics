using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CBoardImporter))]
public class CBoardImpoterEditor : Editor
{
    public CBoardImporter Current { get { return (CBoardImporter)target; } }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.Space(10.0f);

        if (GUILayout.Button("Load"))
        {
            Current.LoadMapFromTexture();
        }

        if (GUILayout.Button("Clear"))
        {
            Current.Clear();
        }

        if (GUILayout.Button("Save as asset"))
        {
            Current.SaveToScriptableObject("TestMap");
        }
    }
}