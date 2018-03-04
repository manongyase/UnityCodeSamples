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
public class CustomPropertyTest : MonoBehaviour
{
    public CustomThing   oneThing;
    public CustomThing[] manyThing;


//----------------------------------------------------------------------------------------------------------------------


    public enum Group 
    { 
        One,
        Two,
        Three, 
        Four,
    }


    /// <summary>
    /// Custom serializable class, drawn by MyCustomPropertyDrawer.
    /// </summary>
    [System.Serializable]
    public class CustomThing
    {
        public string name;
        public int    amount;
        public Group  group;
    }
}
