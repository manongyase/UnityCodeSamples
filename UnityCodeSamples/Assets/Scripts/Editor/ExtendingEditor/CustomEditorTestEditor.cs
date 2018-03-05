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
using System;
using UnityEditor.AnimatedValues;

[CanEditMultipleObjects, CustomEditor(typeof(CustomEditorTest))]
public class CustomEditorTestEditor : Editor
{
    private MonoScript monoScript;
    private GUIContent boolValueContent;
    private AnimBool   fadeGroup;
    private enumTypes  types;
    private float      selectOption;
    private Vector2    scrollPos;
    private bool       toggleGroup;
    private bool       toggle;


    private void OnEnable()
    {
        this.monoScript       = MonoScript.FromMonoBehaviour(this.target as MonoBehaviour);
        this.boolValueContent = new GUIContent("Other Name", "This is tip");
        this.fadeGroup        = new AnimBool(true);
        this.types            = enumTypes.Four;

        this.fadeGroup.valueChanged.AddListener(this.Repaint);
    }


    private void OnDisable()
    {
        this.fadeGroup.valueChanged.RemoveListener(this.Repaint);
    }


    public override void OnInspectorGUI()
    {
        this.serializedObject.Update();

        // draw disabled MonoScript

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.ObjectField("Script", this.monoScript, typeof(MonoScript), false);
        EditorGUI.EndDisabledGroup();

//----------------------------------------------------------------------------------------------------------------------

        // draw intValue and boolValue, and boolValue has custom label display

        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("intValue"));
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("boolValue"), this.boolValueContent);
        var v2Property = this.serializedObject.FindProperty("v2");
        EditorGUILayout.PropertyField(v2Property);
        v2Property.FindPropertyRelative("x").floatValue = 999.0f;

        EditorGUILayout.Separator();

//----------------------------------------------------------------------------------------------------------------------

        // draw array of elements

        var elements = this.serializedObject.FindProperty("floatArray");

        if (EditorGUILayout.PropertyField(elements))
        {
            EditorGUI.indentLevel++;
            elements.arraySize = EditorGUILayout.DelayedIntField("Size", elements.arraySize);

            for (int i = 0, size = elements.arraySize; i < size; i++)
            {
                var element = elements.GetArrayElementAtIndex(i);
                EditorGUILayout.PropertyField(element);
            }

            EditorGUI.indentLevel--;
        }

        EditorGUILayout.Space();

//----------------------------------------------------------------------------------------------------------------------

        this.fadeGroup.target = EditorGUILayout.Foldout(this.fadeGroup.target, "BeginFadeGroup", true);

        if (EditorGUILayout.BeginFadeGroup(this.fadeGroup.faded))
        {
            EditorGUILayout.BoundsField("BoundsField", new Bounds());
            EditorGUILayout.BoundsIntField("BoundsIntField", new BoundsInt());
        }

        EditorGUILayout.EndFadeGroup();

        GUILayout.Space(10);

//----------------------------------------------------------------------------------------------------------------------

        EditorGUILayout.BeginHorizontal(GUI.skin.box);

        EditorGUILayout.LabelField("This is BeginHorizontal", GUILayout.MaxWidth(150.0f));
        EditorGUILayout.DelayedDoubleField(11.1f);
        EditorGUILayout.DelayedTextField("DelayedTextField");
        EditorGUILayout.DropdownButton(GUIContent.none, FocusType.Passive);

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Separator();

//----------------------------------------------------------------------------------------------------------------------

        EditorGUILayout.BeginVertical(GUI.skin.box);

        GUILayout.Box("This is BeginVertical");
        EditorGUILayout.ColorField("ColorField", Color.yellow);
        EditorGUILayout.CurveField("CurveField", new AnimationCurve(), GUILayout.MaxWidth(400.0f));
        EditorGUILayout.HelpBox("HelpBox", MessageType.Info);
        EditorGUILayout.EnumFlagsField("EnumFlagsField", this.types);
        EditorGUILayout.EnumPopup("EnumPopup", this.types);

        this.selectOption = EditorGUILayout.IntPopup("IntPopup",   (int) this.selectOption, new string[] {"0", "1", "2"}, new int[] {0, 1, 2});
        this.selectOption = EditorGUILayout.IntSlider("IntSlider", (int) this.selectOption, 0, 2);
        this.selectOption = EditorGUILayout.MaskField("MaskField", (int) this.selectOption, new string[] {"mask1", "mask2", "mask3"});
        this.selectOption = EditorGUILayout.Popup("Popup", (int) this.selectOption, new string[] {"s1", "s2", "s3"});
       
        EditorGUILayout.EndVertical();

        EditorGUILayout.Separator();

//----------------------------------------------------------------------------------------------------------------------

        this.scrollPos   = EditorGUILayout.BeginScrollView(this.scrollPos, GUI.skin.box);

        GUILayout.Box("this is BeginScrollView");
        EditorGUILayout.TextArea("this is TextArea");
        EditorGUILayout.RectField("RectField", new Rect());
        this.toggle      = EditorGUILayout.Toggle("Toggle", this.toggle);
        this.toggleGroup = EditorGUILayout.BeginToggleGroup("BeginToggleGroup", this.toggleGroup);

        GUILayout.Button("Btn1");
        GUILayout.Button("Btn2");
        GUILayout.Button("Btn3");

        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.EndScrollView();

        this.serializedObject.ApplyModifiedProperties();
    }


    public void OnSceneGUI()
    {
        
    }


//----------------------------------------------------------------------------------------------------------------------


    private enum enumTypes
    {
        One,
        Two,
        Three,
        Four,
    };
}
