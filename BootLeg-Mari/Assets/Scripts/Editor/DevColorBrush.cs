using UnityEditor;
using UnityEngine;


public class DevColorBrush : EditorWindow
{
    [MenuItem("Window/DevColorTool")]
    public static void ShowWindow()
    {
        GetWindow<DevColorBrush>("Dev Color");
    }

    public Material[] _colorMaterials;
    SerializedObject so; 
    private ushort _colorToUse;

    private Color _color;

    private void OnEnable()
    {
        ScriptableObject target = this;
        so = new SerializedObject(target);
    }

    private void OnGUI()
    {


        GUILayout.Label("Color you want to give the gameobjeckt");
        _color = EditorGUILayout.ColorField("Color", _color);

        if (GUILayout.Button("Color with color Objeckt"))
        {
            UsingBasitColor();
        }

        GUILayout.Space(20);

        GUILayout.Label("Matirals");
        #region shows the matiral array and alowes modefikason
        // "target" can be any class derived from ScriptableObject 
        // (could be EditorWindow, MonoBehaviour, etc)
        so.Update();
        SerializedProperty stringsProperty = so.FindProperty("_colorMaterials");

        EditorGUILayout.PropertyField(stringsProperty, true); // True means show children
        so.ApplyModifiedProperties(); // Remember to apply modified properties
        #endregion

        GUILayout.Space(-10);
        GUILayout.Label("Matiral you want to use");
        _colorToUse = (ushort)EditorGUILayout.Slider(_colorToUse, 0, _colorMaterials.Length -1);

        if (GUILayout.Button("Set matiral Objeckt to"))
        {
            UsingMatiralColor(_colorToUse);
        }

    }

    #region
    void UsingBasitColor()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = _color;
            }
        }
    }

    void UsingMatiralColor(ushort colorToUse)
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = _colorMaterials[_colorToUse];
            }
        }
    }
    #endregion
}
