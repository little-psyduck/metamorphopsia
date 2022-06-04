using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItools
{
    private GameObject active_panel;

    public UItools(GameObject panel)
    {
        active_panel = panel;
    }
    public T GetOrAddComponent<T>() where T: Component
    {
        if (active_panel.GetComponent<T>() == null)
        {
            active_panel.AddComponent<T>();
        }
        return active_panel.GetComponent<T>();
    }

    public GameObject FindChildGameObject(string name)
    {
        Transform[] transform = active_panel.GetComponentsInChildren<Transform>();
        foreach (Transform item in transform)
        {
            if (item.name == name)
                return item.gameObject;
        }
        Debug.LogError("can't find object.");
        return null;
    }

    public T GetOrAddComponentInChildren<T>(string name) where T : Component
    {
        GameObject child = FindChildGameObject(name);
        if (child)
        {
            if (child.GetComponent<T>() == null)
                child.AddComponent<T>();
            return child.GetComponent<T>();
        }
        return null;
    }
}
