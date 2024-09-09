using System;
using UnityEditor;
using UnityEngine;
using static PlasticGui.WorkspaceWindow.Topbar.GetShorten;

namespace Kevin.VRChat.Base.Editor
{
    public class CommonScripts
    {
        public GUIContent GrabComponentIcon(Component component, Type type)
        {
            GUIContent content = EditorGUIUtility.ObjectContent(component, type);
            SetIconSize();
            content.text = "";

            return content;
        }

        public GUIContent GrabComponentIcon(Component component, Type type, Texture image)
        {
            GUIContent content = EditorGUIUtility.ObjectContent(component, type);
            SetIconSize();
            content.image = image;
            content.text = "";

            return content;
        }

        private static void SetIconSize()
        {
            float size = 10f;
            Vector2 iconSize = new Vector2(size, size);
            EditorGUIUtility.SetIconSize(iconSize);
        }
    }
}