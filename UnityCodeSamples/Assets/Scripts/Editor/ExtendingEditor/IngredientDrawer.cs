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

[CustomPropertyDrawer(typeof(IngredientDisplay.Ingredient))]
public class IngredientDrawer : PropertyDrawer
{
    /// <summary>
    /// Draw the property inside the given rect
    /// </summary>
    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) 
    {
        // using BeginProperty - EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // draw label
        position   = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // don't make child fields be indented
        var indent = EditorGUI.indentLevel;

        EditorGUI.indentLevel = 0;

        // calculate rects
        Rect amountRect = new Rect(position.x,         position.y, 30.0f,                  position.height);
        Rect unitRect   = new Rect(position.x + 35.0f, position.y, 50.0f,                  position.height);
        Rect nameRect   = new Rect(position.x + 90.0f, position.y, position.width - 90.0f, position.height);

        // draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("amount"), GUIContent.none);
        EditorGUI.PropertyField(unitRect,   property.FindPropertyRelative("unit"),   GUIContent.none);
        EditorGUI.PropertyField(nameRect,   property.FindPropertyRelative("name"),   GUIContent.none);

        // set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}

