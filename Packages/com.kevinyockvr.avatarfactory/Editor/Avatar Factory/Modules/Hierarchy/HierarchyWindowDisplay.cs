using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VRC.SDK3.Dynamics.PhysBone.Components;
using VRC.SDK3.Dynamics.Contact.Components;
using VRC.SDK3.Avatars.Components;
using UnityEngine.UI;

namespace Kevin.VRChat.Base.Editor
{
    /*
     * Credit to Warped Imagination the video
     * https://www.youtube.com/watch?v=EFh7tniBqkk
     */
    [InitializeOnLoad]
    public static class HierarchyWindowDisplay
    {
        /*
         * Order of which components shown to be able to toggle
         * From Right To Left (Top to Bottom)
         * GameObject (Technically not acomponent)
         */

        static int _max_togglable_components = 10;

        static bool _hierarchyHasFocus = false;

        static EditorWindow _hierarchyEditorWindow;

        static readonly CommonScripts commonScripts = new();

        static readonly VRCComponentDisplay vrcComponentDisplay = new();

        static readonly UnityComponentsDisplay unityComponentsDisplay = new();

        static HierarchyWindowDisplay()
        {
            EditorApplication.hierarchyWindowItemOnGUI += DrawWindowItemOnGUI;

            EditorApplication.update += OnEditorUpdate;
        }

        private static void OnEditorUpdate()
        {
            if (_hierarchyEditorWindow == null)
                _hierarchyEditorWindow = EditorWindow.GetWindow(Type.GetType("UnityEditor.SceneHierarchyWindow,UnityEditor"));

            _hierarchyHasFocus = EditorWindow.focusedWindow != null &&
                EditorWindow.focusedWindow == _hierarchyEditorWindow;
        }
        private static void DrawWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null)
                return;

            if (PrefabUtility.GetCorrespondingObjectFromSource(gameObject) != null)
                return;

            HierarcyWindowItemColor(gameObject, selectionRect);

            DrawComponentIcon(gameObject, instanceID, selectionRect);

            SetUpToggle(gameObject, selectionRect);
        }


        private static void HierarcyWindowItemColor(GameObject gameObject, Rect selectionRect)
        {
            Color color = new(0, 0, 0, 0);
            Rect backgroundRect = selectionRect;

            switch (gameObject.name)
            {
                default:
                    break;
            }
            EditorGUI.DrawRect(backgroundRect, color);
        }

        private static void DrawComponentIcon(GameObject gameObject, int instanceID, Rect selectionRect)
        {
            Component[] components = gameObject.GetComponents<Component>();

            if (components == null || components.Length == 0)
                return;

            Component component = components.Length > 1 ? components[1] : components[0];


            Type type = component.GetType();

            GUIContent content = EditorGUIUtility.ObjectContent(component, type);
            content.text = null;
            content.tooltip = type.Name;


            if (content.image == null)
                return;

            bool isSelected = Selection.instanceIDs.Contains(instanceID);

            bool isHovering = selectionRect.Contains(Event.current.mousePosition);

            Color color = UnityEditorBackgroundColor.Get(isSelected, isHovering, _hierarchyHasFocus);
            Rect backgroundRect = selectionRect;
            backgroundRect.width = 18.5f;

            EditorGUI.DrawRect(backgroundRect, color);
            EditorGUI.LabelField(selectionRect, content);
        }

        private static List<Component> GetComponents(GameObject gameObject)
        {
            List<Component> list = new List<Component>();

            VRCPhysBone physBone = gameObject.GetComponent<VRCPhysBone>();
            if (physBone != null)
            {
                list.Add(physBone);
            }
            // Reserved for VRC Constraints
            // VRCConstraints vrcConstraints

            // Reserved for VRC Constraints
            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                list.Add(meshRenderer);
            }

            SkinnedMeshRenderer skinnedMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
            if (skinnedMeshRenderer != null)
            {
                list.Add(skinnedMeshRenderer);
            }

            return list;
        }

        private static void SetUpToggle(GameObject gameObject, Rect selectionRect)
        {
            // Toggle the gameObject

            Rect toggleRect = selectionRect;
            toggleRect.width = 18.5f;
            toggleRect.x = Screen.width - (toggleRect.width * 2);

            unityComponentsDisplay.ToggleGameObject(gameObject, toggleRect);

            List<Component> list = GetComponents(gameObject);

            if(list.Count > _max_togglable_components)
            {
                Debug.LogWarning("Approaching to unsafe amount of components in one of the gameobjects");
            }

            // VRC Components Go First
            VRCContactReceiver vrcContactReceiver = gameObject.GetComponent<VRCContactReceiver>();
            if(vrcContactReceiver != null)
            {
                toggleRect.x -= toggleRect.width;
                vrcComponentDisplay.ToggleContactReceiver(vrcContactReceiver, toggleRect);
            }

            VRCContactSender vrcContactSender = gameObject.GetComponent<VRCContactSender>();
            if(vrcContactSender != null)
            {
                toggleRect.x -= toggleRect.width;
                vrcComponentDisplay.ToggleContactSender(vrcContactSender, toggleRect);
            }

            // Reserved

            // VRCConstraint vrcConstraint = gameObject.GetComponent<VRCConstraint>()
            // if (vrcConstraint != null)
            // {
            //    toggleRect.x -= toggleRect.width;
            //    ToggleHeadChop(headChop, toggleRect);
            // }

            // Reserved

            VRCPhysBoneCollider physBoneCollider = gameObject.GetComponent<VRCPhysBoneCollider>();
            if (physBoneCollider != null)
            {
                toggleRect.x -= toggleRect.width;
                vrcComponentDisplay.TogglePhysBoneCollider(physBoneCollider, toggleRect);
            }

            VRCPhysBone physBone = gameObject.GetComponent<VRCPhysBone>();
            if (physBone != null)
            {
                toggleRect.x -= toggleRect.width;
                vrcComponentDisplay.TogglePhysBone(physBone, toggleRect);
            }

            VRCHeadChop headChop = gameObject.GetComponent<VRCHeadChop>();
            if (headChop != null)
            {
                toggleRect.x -= toggleRect.width;
                vrcComponentDisplay.ToggleHeadChop(headChop, toggleRect);
            }

            VRCStation vrcStation = gameObject.GetComponent<VRCStation>();
            if (vrcStation != null)
            {
                toggleRect.x -= toggleRect.width;
                vrcComponentDisplay.ToggleVRCStation(vrcStation, toggleRect);
            }

            // Unity Builtin
            Light light = gameObject.GetComponent<Light>();
            if (light != null)
            {
                toggleRect.x -= toggleRect.width;
                unityComponentsDisplay.ToggleLight(light, toggleRect);
            }

            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                toggleRect.x -= toggleRect.width;
                unityComponentsDisplay.ToggleAudioSource(audioSource, toggleRect);
            }

            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                toggleRect.x -= toggleRect.width;
                unityComponentsDisplay.ToggleMeshRenderer(meshRenderer, toggleRect);
            }

            SkinnedMeshRenderer skinMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
            if (skinMeshRenderer != null)
            {
                toggleRect.x -= toggleRect.width;
                unityComponentsDisplay.ToggleSkinnedMeshRenderer(skinMeshRenderer, toggleRect);
            }

            BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                toggleRect.x -= toggleRect.width;
                unityComponentsDisplay.ToggleBoxCollider(boxCollider, toggleRect);
            }
        }
    }
}