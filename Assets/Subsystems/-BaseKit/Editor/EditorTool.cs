using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorUtil 
{
    [MenuItem("EditorTool/DeletePlayerPrefs")]
    public static void PlayerPrefsDeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

}
