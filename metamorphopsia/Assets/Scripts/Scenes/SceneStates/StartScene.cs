using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : SceneState
{
    readonly string scene_name = "StartScene";
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
            panel_manager.Push(new StartPanel());
    }
    public override void OnSleep()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        panel_manager.Pop();
    }

    private void SceneLoaded(Scene scene,LoadSceneMode load)
    {
        panel_manager.Push(new StartPanel());
        Debug.Log("Start scene loading complete.");
    }
}
