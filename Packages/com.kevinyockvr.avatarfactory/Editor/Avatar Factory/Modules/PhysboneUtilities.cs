using UnityEditor;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Dynamics.PhysBone.Components;

namespace Kevin.VRChat.Base.Utilities
{
    public class PhysboneUtilities : MonoBehaviour
    {
        private static readonly string physbone = "Physbone";

        private static readonly string[] physBoneGroupName =
        {
            "Breasts",
            "Ass"
        };

        private static GameObject go_physbone = null;
        private static void CreateChildPhysbone(string name, GameObject parentGameObject)
        {
            GameObject childGameObject = new GameObject(name);
            childGameObject.transform.parent = parentGameObject.transform;
            childGameObject.AddComponent<VRCPhysBone>();
        }

        [MenuItem("GameObject/Tools/Physbone/Add Basic Physbone")]
        private static void CreateBasePhysbone()
        {
            GameObject selectedObject = Selection.activeGameObject;

            if (!selectedObject.GetComponent<VRCAvatarDescriptor>())
                return;

            if(go_physbone == null)
                go_physbone = new GameObject(physbone);


            go_physbone.transform.parent = selectedObject.transform;
            CreateChildPhysbone(physBoneGroupName[0], go_physbone);
            CreateChildPhysbone(physBoneGroupName[1], go_physbone);
        }

        [MenuItem("GameObject/Tools/Physbone/Add Hair Physbone")]
        private static void CreateHairPhysbone()
        {
            assignRootPhysbone();
            GameObject selectedObject = Selection.activeGameObject;
            CreateChildPhysbone("Hair 1", go_physbone);


        }

        [MenuItem("GameObject/Tools/Physbone/Add Breast Physbone")]
        private static void CreateBreastPhysbone()
        {
            assignRootPhysbone();
            GameObject selectedObject = Selection.activeGameObject;

        }

        [MenuItem("GameObject/Tools/Physbone/Add Ass Physbone")]
        private static void CreateAssPhysbone()
        {
            assignRootPhysbone();
            GameObject selectedObject = Selection.activeGameObject;

        }

        private static void assignRootPhysbone()
        {
            if (go_physbone == null)
                go_physbone = GameObject.Find(physbone);
        }
    }
}
