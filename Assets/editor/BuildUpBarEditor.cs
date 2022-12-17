using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildUpBar))]
public class NewBehaviourScript : Editor
{
    BuildUpBar bar;
    float prevBarValueAtRelease;

    public void OnEnable()
    {
        bar = (BuildUpBar)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.FloatField("BarValueAtRelease", bar.BarValueAtRelease);
        if (GUILayout.Button("Reset")) bar.Reset();
    }

    public override bool RequiresConstantRepaint()
    {
        return prevBarValueAtRelease != bar.BarValueAtRelease;
    }
}
