using UnityEditor;
using UnityEngine;

namespace Kevin.VRChat.Base.Editor
{
    public class GameObjectUtilities : MonoBehaviour
    {
        private static string[] m_GameObjectLabels =
        {

        };

        [MenuItem("GameObject/Tools/GameObject/GameObject Seperator", false, 0)]
        private static void CreateGameObjectSeperator()
        {
            GameObject seperator = new GameObject("---------------------");
        }

        [MenuItem("GameObject/Tools/GameObject/Capitalize Name")]
        private static void CapitalizedGameObjectName()
        {
            Object selectedObject = Selection.activeObject;
            selectedObject.name = selectedObject.name.ToUpper();
        }

        [MenuItem("GameObject/Tools/GameObject/Lowercase Name")]
        private static void LowercaseGameObjectName()
        {
            Object selectedObject = Selection.activeObject;
            selectedObject.name = selectedObject.name.ToLower();
        }

        [MenuItem("GameObject/Tools/GameObject/Reset Transform")]
        private static void ResetTransform()
        {
            Transform selectedTransform = Selection.activeTransform;
            selectedTransform.position = Vector3.zero;
            selectedTransform.rotation = Quaternion.identity;
            selectedTransform.localScale = Vector3.one;
        }

        [MenuItem("GameObject/Tools/GameObject/Reset Name")]
        private static void ResetName()
        {
            GameObject[] selectedObjects = Selection.gameObjects;

            if (selectedObjects.Length < 1)
                return;

            foreach (GameObject obj in selectedObjects)
            {
                int start = obj.name.IndexOf("(");
                int end = obj.name.IndexOf("(");

                if(start != -1 && end != -1 && start < end)
                {
                    obj.name = obj.name.Substring(0, start);
                }
            }
        }

        private static void OrganizeGameObjectAlphabetically()
        {
            GameObject selectedGameObject = Selection.activeGameObject;
            if (selectedGameObject.transform.childCount < 1)
                return;
        }
        private static void OrganizeGameObjectReverseAlphabetically()
        {
            GameObject selectedGameObject = Selection.activeGameObject;
            if (selectedGameObject.transform.childCount < 1)
                return;
        }
    }
}
