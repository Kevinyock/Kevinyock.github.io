using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using Kevin.VRChat.Base.Utilities;
using System;
using System.Linq;
// using Thry;

namespace Kevin.VRChat.Base.Editor
{
    public class UtilitiesEditor : MonoBehaviour
    {
        private static string[] keywords = {
            ".meta",

        };

        private static string[] imageFileType = {
            ".png"
        };

        private static string[] videoFileType =
        {
            ".mp4"
        };

        private static string[] shaderName =
        {
            ".poiyomi/Poiyomi Pro"
        };

        private static string[] texturemaps =
        {
            "base_color",
            "emissive",
            "metallic",
            "normal",
            "roughness",
        };

        [MenuItem("Assets/Create/KevinyockVR/Utilities/Text File", false, 1)]
        private static void CreateNewTextFile()
        {
            ProjectWindowUtil.CreateAssetWithContent(
                "Default Name.txt",
                string.Empty);
        }

        [MenuItem("Assets/Create/KevinyockVR/Utilities/Base Folders")]
        private static void CreateBaseFolders()
        {
            string currentSelectionPath = Common.GetProjectActiveDirectory();
            AssetDatabase.CreateFolder(currentSelectionPath, "Animations");
            AssetDatabase.CreateFolder(currentSelectionPath, "Prefabs");
            AssetDatabase.CreateFolder(currentSelectionPath, "Sounds");
        }

        [MenuItem("Assets/Create/KevinyockVR/Utilities/Strip File Name")]
        private static void RemoveNumbersInFileName()
        {
            string oldFileName = AssetDatabase.GetAssetPath(Selection.activeObject);
            string newFileName = Regex.Replace(oldFileName, "[0-9]", "");
            File.Move(oldFileName, newFileName);
            AssetDatabase.Refresh();
        }

        [MenuItem("Assets/Create/KevinyockVR/Utilities/Create Base Material")]
        private static void CreateBaseMaterial()
        {
            string currentSelectionPath = Common.GetProjectActiveDirectory();
            string currentDirectory = Path.GetDirectoryName(currentSelectionPath);
            string[] fileEntries = Directory.GetFiles(currentDirectory);

            List<string> filteredFiles = new List<string>();

            foreach (string file in fileEntries)
            {
                if (!file.EndsWith(".meta"))
                {
                    Debug.Log(file);
                    filteredFiles.Add(file);
                }
            }

            Texture base_color = Selection.activeObject as Texture;
            Texture normal_map = Selection.activeObject as Texture;
            string name = Selection.activeObject.name;
            Material material = new Material(Shader.Find(shaderName[0]));
            material.SetTexture("_MainTex", base_color);
            //material.SetTexture("_BumpMap", texture);
            AssetDatabase.CreateAsset(material, currentDirectory + $"/{name}.mat");

        }
        [MenuItem("Assets/Create/KevinyockVR/Utilities/Texture/Set All Normal Texture Type to Normal Map")]
        private static void SetAllNormalMapTextureTypeToNormalMap()
        {
            string currentSelectionPath = Common.GetProjectActiveDirectory();

            List<string> files = Directory.GetFiles(currentSelectionPath).ToList();

            List<string> textureList = PurgeAllCertainFileTypeFromList(files,".meta");
            textureList = FilterFileByName(textureList,"normal");
            
            foreach (string texture in textureList)
            {
                TextureImporter textureImporter = (TextureImporter)AssetImporter.GetAtPath(texture);
                textureImporter.textureType = TextureImporterType.NormalMap;
            }
        }

        [MenuItem("Assets/Create/KevinyockVR/Utilities/Texture/Set All Texture To 1024")]
        private static void SetAllTextureMaxSizeTo1024()
        {
            SetAllTextureMaxSizeTo1024(1024);
        }

        [MenuItem("Assets/Create/KevinyockVR/Utilities/Texture/Set All Texture To 512")]
        private static void SetAllTextureMaxSizeTo512()
        {
            SetAllTextureMaxSizeTo1024(512);
        }

        private static void SetAllTextureMaxSizeTo1024(int size)
        {
            string[] results = AssetDatabase.FindAssets("t:texture2d", new string[] { "Assets"});

            List<string> listOfFileNames = new();

            foreach(string guid in results)
            {
                listOfFileNames.Add(AssetDatabase.GUIDToAssetPath(guid));
            }

            listOfFileNames = PurgeAllCertainFileTypeFromList(listOfFileNames,".ttf");

            foreach (string filename in listOfFileNames)
            {
                TextureImporter textureImporter = (TextureImporter)AssetImporter.GetAtPath(filename);
                TextureImporterSettings settings = new TextureImporterSettings();

                int textureSize = textureImporter.maxTextureSize;
                if (textureSize < size)
                {
                    continue;
                }
                textureImporter.maxTextureSize = size;

                textureImporter.SetTextureSettings(settings);

            }

        }

        private static List<string> PurgeAllCertainFileTypeFromList(List<string> listOfFiles, string filetype)
        {

            List<string> filesWithNoMetaType = new List<string>();

            foreach (string file in listOfFiles)
            {
                if(file.Contains(filetype))
                {
                    continue;
                }
                filesWithNoMetaType.Add(file);
            };
            return filesWithNoMetaType;
        }

        private static List<string> FilterFileByName(List<string> listOfFiles,string name)
        {
            List<string> filteredList = new List<string>();
            foreach (string file in listOfFiles)
            {
                if (!file.Contains(name))
                {
                    continue;
                }
                filteredList.Add(file);
            };
            foreach (string file in filteredList)
            {
                Debug.Log(file);
            };
            return filteredList;
        }

        //[MenuItem("Assets/Create/KevinyockVR/Utilities/Create Materials")]
        private static void CreateBaseMaterials()
        {
            string currentSelectionPath = Common.GetProjectActiveDirectory();
            string[] ListOfTextures = AssetDatabase.FindAssets("t:texture", new string[] { currentSelectionPath });
            AssetDatabase.GUIDToAssetPath(currentSelectionPath);
            foreach (string texture in ListOfTextures)
            {
                Debug.Log(texture);
            }
            List<string> materialList = new List<string>();

            /*
            foreach(string file in filelist)
            {
                if (!file.Contains(keywords[0]))
                {
                    materialList.Add(file);
                }
            }

            foreach (string file in materialList)
            {
                Material material = new Material(Shader.Find("Standard"));
                AssetDatabase.CreateAsset(material, currentSelectionPath + $"/{file}.mat");
            }
            */
        }
    }
}
