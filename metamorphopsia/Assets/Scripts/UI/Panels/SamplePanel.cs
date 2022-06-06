using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamplePanel : BasePanel
{
    static readonly string path = "UI Panels/sample_panel";
    public SamplePanel() : base(new UIType(path)) { }
    public override void OnAwake()
    {
        ui_tool.GetOrAddComponentInChildren<Button>("quit_button").onClick.AddListener(() =>
        {
            GameRoot.Instance.scene_system.SetScene(new StartScene());
        });
    }
}
