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


/// <summary>
/// Tell the RangeDrawer that it is a drawer for properties with the RangeAttribute.
/// </summary>
[CustomPropertyDrawer(typeof(RangeAttribute))]
public class CustomRangeDrawer : PropertyDrawer
{
    /// <summary>
    /// Draw the property inside the given rect
    /// </summary>
    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) 
    {
        // first get the attribute since it contains the range for the slider
        var range = this.attribute as RangeAttribute;

        // now draw the property as a Slider or an IntSlider based on whether it's a float or integer.
        if (property.propertyType == SerializedPropertyType.Float)
        {
            EditorGUI.Slider(position, property, range.min, range.max, label);
        }
        else if (property.propertyType == SerializedPropertyType.Integer)
        {
            EditorGUI.IntSlider(position, property, (int) range.min, (int) range.max, label);
        }
        else
        {
            EditorGUI.LabelField(position, label.text, "Use Range with float or int.");
        }
    }
}
