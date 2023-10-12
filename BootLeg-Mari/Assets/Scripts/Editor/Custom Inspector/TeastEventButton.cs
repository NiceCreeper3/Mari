using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEventScriptebolObjecks))]
public class TeastEventButton : Editor
{
   [SerializeField] public ushort _giveUshortVaue;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameEventScriptebolObjecks gameEventRefrens = (GameEventScriptebolObjecks)target;

        // Leats us send difrent nummberes ind the event
        EditorGUILayout.TextField("Indput the nummber you want to send. reamber this is ushort");
        _giveUshortVaue = (ushort)EditorGUILayout.Slider(_giveUshortVaue, 0, 10);


        if (GUILayout.Button("Trigger ushort event"))
        {
            gameEventRefrens.Raise(_giveUshortVaue);
        }
    }
}
