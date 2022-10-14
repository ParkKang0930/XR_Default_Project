using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Device_Selector))]
public class Edit_Device_Selector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Device_Selector DS = (Device_Selector)target;

        if (GUILayout.Button("Pico로 변경"))
            DS.Start_Pico();
        if (GUILayout.Button("Oculus로 변경"))
            DS.Start_Oculus();
    }
}
