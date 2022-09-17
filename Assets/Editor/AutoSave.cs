using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class AutoSave : EditorWindow
{
    private float _timeBtwSaves = 100;
    private float _nextSaveTime = 0;

    //under wimndow tab names as AutoSave
    [MenuItem("Window/AutoSave")]

    public static void ShowWindow()
    {
        GetWindow<AutoSave>("Auto Save");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Time between saves: "+ _timeBtwSaves + "secs");
        float timeLeftToSave = _nextSaveTime - (float)EditorApplication.timeSinceStartup;
        EditorGUILayout.LabelField("Time left for save: " + timeLeftToSave + "secs");
        //Repaint();
        if (_nextSaveTime <= EditorApplication.timeSinceStartup)
        {
            _nextSaveTime = _timeBtwSaves + (float)EditorApplication.timeSinceStartup;
            EditorSceneManager.SaveOpenScenes();
        }
    }
}