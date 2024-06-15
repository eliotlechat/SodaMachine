using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InstantiateGameObject))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        //EditorGUILayout.LabelField("Hey, this is our custom field");
        DrawDefaultInspector();

        InstantiateGameObject instGO= (InstantiateGameObject)target;
        if (GUILayout.Button("Create"))
        {
            instGO.InstantiateObjectAtPosition();
        }
    }
}
