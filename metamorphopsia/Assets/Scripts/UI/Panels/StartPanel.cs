using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    static readonly string path = "UI Panels/start_panel";
    public StartPanel() : base(new UIType(path)) { }
    public override void OnAwake()
    {
        ui_tool.GetOrAddComponentInChildren<Button>("quit").onClick.AddListener(() =>
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        });
        ui_tool.GetOrAddComponentInChildren<Button>("grid_enter").onClick.AddListener(() =>
        {
            GameRoot.Instance.scene_system.SetScene(new SampleScene());
        });

        ui_tool.GetOrAddComponentInChildren<Button>("remap_enter").onClick.AddListener(() =>
        {
            GameRoot.Instance.scene_system.SetScene(new ShowScene());
        });
    }
}
