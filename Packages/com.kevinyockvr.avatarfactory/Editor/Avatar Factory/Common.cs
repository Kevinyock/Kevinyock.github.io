using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Kevin.VRChat.Base.Utilities
{
    public class Common : MonoBehaviour
    {
        [MenuItem("Assets/Create/KevinyockVR/Ping")]
        [MenuItem("Assets/Ping")]
        public static string GetProjectActiveDirectory()
        {
            Type projectWindowUtilType = typeof(ProjectWindowUtil);
            MethodInfo getActiveFolderPath = projectWindowUtilType.GetMethod("GetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic);
            object obj = getActiveFolderPath.Invoke(null, new object[0]);
            string pathToCurrentFolder = obj.ToString();
            // Debug.Log(pathToCurrentFolder);
            return pathToCurrentFolder;
        }
    }
}