using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(COVRPlayerController))]
public class COVRPlayerControllerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        COVRPlayerController targetScript = (COVRPlayerController)target;
        targetScript.movementSpeedMultiplier = EditorGUILayout.Slider("Speed Multiplier", targetScript.movementSpeedMultiplier, 0.0f, 10.0f);
        targetScript.useProfileHeight = EditorGUILayout.Toggle("Use Profile Height", targetScript.useProfileHeight);
    }

    public void OnSceneGUI()
    {

    }

}
