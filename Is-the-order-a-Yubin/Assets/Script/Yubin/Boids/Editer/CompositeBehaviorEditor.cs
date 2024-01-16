using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CompositeBehavior))]
public class CompositeBehaviorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //setup
        CompositeBehavior cb = (CompositeBehavior)target;

        //check for behaviors
        if (cb.behaviors == null || cb.behaviors.Length == 0)
        {
            EditorGUILayout.HelpBox("No behaviors in array.", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.LabelField("Behaviors");
            EditorGUILayout.LabelField("Weights");

            EditorGUI.BeginChangeCheck();
            for (int i = 0; i < cb.behaviors.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.LabelField(i.ToString(), GUILayout.Width(20f));
                cb.behaviors[i] = (BoidsBehavior)EditorGUILayout.ObjectField(cb.behaviors[i], typeof(BoidsBehavior), false);
                cb.weights[i] = EditorGUILayout.FloatField(cb.weights[i], GUILayout.Width(60f));

                EditorGUILayout.EndHorizontal();
            }
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(cb);
            }
        }

        EditorGUILayout.BeginHorizontal();

        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Add Behavior", GUILayout.Width(100f)))
        {
            AddBehavior(cb);
            EditorUtility.SetDirty(cb);
        }

        if (cb.behaviors != null && cb.behaviors.Length > 0 && GUILayout.Button("Remove Behavior", GUILayout.Width(120f)))
        {
            RemoveBehavior(cb);
            EditorUtility.SetDirty(cb);
        }

        EditorGUILayout.EndHorizontal();
    }

    void AddBehavior(CompositeBehavior cb)
    {
        int oldCount = (cb.behaviors != null) ? cb.behaviors.Length : 0;
        BoidsBehavior[] newBehaviors = new BoidsBehavior[oldCount + 1];
        float[] newWeights = new float[oldCount + 1];
        for (int i = 0; i < oldCount; i++)
        {
            newBehaviors[i] = cb.behaviors[i];
            newWeights[i] = cb.weights[i];
        }
        newWeights[oldCount] = 1f;
        cb.behaviors = newBehaviors;
        cb.weights = newWeights;
    }

    void RemoveBehavior(CompositeBehavior cb)
    {
        int oldCount = cb.behaviors.Length;
        if (oldCount == 1)
        {
            cb.behaviors = null;
            cb.weights = null;
            return;
        }
        BoidsBehavior[] newBehaviors = new BoidsBehavior[oldCount - 1];
        float[] newWeights = new float[oldCount - 1];
        for (int i = 0; i < oldCount - 1; i++)
        {
            newBehaviors[i] = cb.behaviors[i];
            newWeights[i] = cb.weights[i];
        }
        cb.behaviors = newBehaviors;
        cb.weights = newWeights;
    }
}
