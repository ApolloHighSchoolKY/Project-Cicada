using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class AutoSaver
{
    static AutoSaver()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        EditorApplication.playmodeStateChanged += SaveScene;
#pragma warning restore CS0618 // Type or member is obsolete
    }

    static void SaveScene()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                Debug.Log("Auto-Saving scene before entering Play mode: " + EditorSceneManager.GetActiveScene().name);
                EditorSceneManager.SaveOpenScenes();
                AssetDatabase.SaveAssets();
            }
#pragma warning disable CS0618 // Type or member is obsolete
        EditorApplication.playmodeStateChanged -= SaveScene;
#pragma warning restore CS0618 // Type or member is obsolete
    }
}
