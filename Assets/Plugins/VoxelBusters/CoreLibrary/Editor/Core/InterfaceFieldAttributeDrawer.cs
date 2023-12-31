﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.CoreLibrary.Editor
{
    [CustomPropertyDrawer(typeof(InterfaceFieldAttribute))]
    public class InterfaceFieldAttributeDrawer : PropertyDrawer 
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            // draw property
            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, property, label);
            if (EditorGUI.EndChangeCheck())
            {
                var reference       = property.objectReferenceValue;
                var interfaceType   = ((InterfaceFieldAttribute)attribute).InterfaceType;
                if (reference && !interfaceType.IsAssignableFrom(reference.GetType()))
                {
                    DebugLogger.LogError("Object does not implement " + interfaceType);
                    property.objectReferenceValue   = null;
                }
            }

            EditorGUI.EndProperty();
        }
    }
}