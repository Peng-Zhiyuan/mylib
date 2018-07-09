using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class PreCompileWindow : EditorWindow {

    public static void Open()
    {
        var window = EditorWindow.GetWindow<PreCompileWindow>("PreCompile", true) as PreCompileWindow;
        window.Show(true);
    }

    public void OnGUI()
    {
        
    }
}
