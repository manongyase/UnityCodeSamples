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
/// Drop on Inspector.
/// </summary>
public class CustomRange : MonoBehaviour 
{
    [Range(0.0f, 10.0f)]
    public float num;
}
