/*
------------------------------------------------------------------------------------------------------------------------
 * Copyright (c) 2018 scott.cgi All Rights Reserved.
 * 
 * This code is licensed under the MIT License.
 *
 * Since  : 2018-3-3
 * Author : scott.cgi
------------------------------------------------------------------------------------------------------------------------
 */

using UnityEngine;
using UnityEditor;

public class EditorWindows : EditorWindow
{
    private bool   isEmpty  = true;

    private string myString = "Hello World";
    private bool   groupEnabled;
    private bool   myBool   = true;
    private float  myFloat  = 1.23f;


    [MenuItem("ExtendingEditor/Normal Window")]
    public static void ShowNormalWindow() 
    {
        var window     = EditorWindow.GetWindow<EditorWindows>(true, "Normal Window", true);
        window.isEmpty = true;
    }


    [MenuItem("ExtendingEditor/Floating Window")]
    public static void ShowFloatingWindow() 
    {
        var window     = EditorWindow.GetWindow<EditorWindows>(false, "Floating Window", true);
        window.isEmpty = true;
    }


    [MenuItem("ExtendingEditor/OnGUI Window")]
    public static void ShowWindow() 
    {
        var window     = EditorWindow.GetWindow<EditorWindows>(true, "OnGUI Window", true);
        window.isEmpty = false;
    }


    private void OnGUI() 
    {
        if (this.isEmpty == false)
        {
            GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
            this.myString     = EditorGUILayout.TextField ("Text Field", myString);

            this.groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
            this.myBool       = EditorGUILayout.Toggle ("Toggle", myBool);
            this.myFloat      = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
            EditorGUILayout.EndToggleGroup ();
        }
    }
}
