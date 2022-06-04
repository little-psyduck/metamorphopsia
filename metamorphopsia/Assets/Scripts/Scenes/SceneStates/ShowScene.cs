using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowScene : SceneState
{
    readonly string scene_name = "ShowScene";
    public override void OnAwake()
    {
        if (SceneManager.GetActiveScene().name != scene_name)
        {
            SceneManager.LoadScene(scene_name);
            SceneManager.sceneLoaded += SceneLoaded;
        }
    }
    public override void OnSleep()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    private void SceneLoaded(Scene scene, LoadSceneMode load)
    {
        Debug.Log("Show scene loading complete.");
    }
}

