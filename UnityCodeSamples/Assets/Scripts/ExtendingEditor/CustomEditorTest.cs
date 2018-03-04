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

/// <summary>
/// Drop to Inspector.
/// </summary>
public class CustomEditorTest : MonoBehaviour 
{
    [Space(10)]
    public int     intValue;
    public bool    boolValue;
    public Vector2 v2;
    public float[] floatArray = new float[] {1.0f, 2.0f, 3.0f};
}
