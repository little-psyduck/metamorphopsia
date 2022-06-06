using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleScene : SceneState
{
    readonly string scene_name = "SampleScene";
    PanelManager panel_manager;

    public override void OnAwake()
    {
        panel_manager = new PanelManager();
        if (SceneManager.GetActiveScene().name != scene_name)
        {
            SceneManager.LoadScene(scene_name);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
            panel_manager.Push(new SamplePanel());
    }
    public override void OnSleep()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        panel_manager.Pop();
    }

    private void SceneLoaded(Scene scene, LoadSceneMode load)
    {
        panel_manager.Push(new SamplePanel());
        Debug.Log("Sample scene loading complete.");
    }
}
