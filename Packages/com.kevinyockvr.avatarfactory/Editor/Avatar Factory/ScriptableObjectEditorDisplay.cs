using UnityEngine;
using UnityEditor;

namespace Kevin.VRChat.Extension
{
    [InitializeOnLoad]
    public class DisplayCustomIcon : Editor
    {
        public static void SetCustomIconOnMonoScript()
        {
            MonoImporter importer = AssetImporter.GetAtPath("Assets/Kevalyn/Kevalyn Expression Menu 1") as MonoImporter;
            Texture2D icon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/KevinyockVR/Editor/Icons/VRCPhysbone.png");
            Debug.Log("Setting Icon");
            importer.SetIcon(icon);
            importer.SaveAndReimport();
        }
    }
}