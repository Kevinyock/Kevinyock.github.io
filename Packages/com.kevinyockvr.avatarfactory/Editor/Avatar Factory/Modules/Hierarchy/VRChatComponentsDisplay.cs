using System;
using UnityEditor;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Dynamics.Contact.Components;
using VRC.SDK3.Dynamics.PhysBone.Components;

namespace Kevin.VRChat.Base.Editor
{
    public class VRCComponentDisplay
    {
        static readonly CommonScripts commonScripts = new();
        public void TogglePhysBoneCollider(VRCPhysBoneCollider physBoneCollider, Rect toggleRect)
        {
            Texture image = (Texture)AssetDatabase.LoadAssetAtPath("Assets/KevinyockVR/Editor/Icons/VRCPhysbone.png", typeof(Texture));

            GUIContent guiContent = commonScripts.GrabComponentIcon(physBoneCollider, physBoneCollider.GetType(), image);

            if (GUI.Button(toggleRect, guiContent))
            {
                physBoneCollider.enabled = !physBoneCollider.enabled;
            }
        }
        public void TogglePhysBone(VRCPhysBone physBone, Rect toggleRect)
        {
            Texture image = (Texture)AssetDatabase.LoadAssetAtPath("Assets/KevinyockVR/Editor/Icons/VRCPhysbone.png", typeof(Texture));

            GUIContent guiContent = commonScripts.GrabComponentIcon(physBone, physBone.GetType(), image);

            if (GUI.Button(toggleRect, guiContent))
            {
                physBone.enabled = !physBone.enabled;
            }
        }

        public void ToggleHeadChop(VRCHeadChop headChop, Rect toggleRect)
        {
            GUIContent guiContent = commonScripts.GrabComponentIcon(headChop, headChop.GetType());
            if (GUI.Button(toggleRect, guiContent))
            {
                headChop.enabled = !headChop.enabled;
            }
        }

        public void ToggleContactReceiver(VRCContactReceiver contactReceiver, Rect toggleRect)
        {
            GUIContent guiContent = commonScripts.GrabComponentIcon(contactReceiver, contactReceiver.GetType());
            if(GUI.Button(toggleRect, guiContent))
            {
                contactReceiver.enabled = !contactReceiver.enabled;
            }
        }

        public void ToggleContactSender(VRCContactSender contactSender, Rect toggleRect)
        {
            GUIContent guiContent = commonScripts.GrabComponentIcon(contactSender, contactSender.GetType());
            if(GUI.Button(toggleRect,guiContent))
            {
                contactSender.enabled = !contactSender.enabled;
            }
        }

        public void ToggleVRCStation(VRCStation vrcStation, Rect toggleRect)
        {
            GUIContent guiContent = commonScripts.GrabComponentIcon(vrcStation, vrcStation.GetType());
            if(GUI.Button(toggleRect,guiContent))
            {
                vrcStation.enabled = !vrcStation.enabled;
            }
        }
    }
}