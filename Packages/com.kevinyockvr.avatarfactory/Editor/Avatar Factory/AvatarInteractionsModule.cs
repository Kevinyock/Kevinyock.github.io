using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Avatars.ScriptableObjects;
using VRC.SDK3.Dynamics.PhysBone.Components;

namespace Kevin.VRChat.Base.Editor.Modules.AvatarInteraction
{
    public class AvatarInteractionModule : EditorBase
    {
        private static readonly string[] bodyParts =
        {
            "Head",
            "Chest",
            "Left Arm",
            "Right Arm",
            "Left Wrist",
            "Right Wrist",
            "Left Leg",
            "Right Leg",
            "Left Ankle",
            "Right Ankle"
        };

        private static readonly string[] eyesBones =
        {
            "Eye_L",
            "Eye_R",
            "LeftEye",
            "RightEye"
        };


        private static Transform[] bodyPartsTransform = new Transform[bodyParts.Length];

        [SerializeField]
        private static VRCAvatarDescriptor VRCAvatarDescriptor;

        #region Avatar Skeleton

        [SerializeField]
        private static bool avatarSkeleton;

        [SerializeField]
        private static Transform armature;

        [SerializeField]
        private static Transform head;

        [SerializeField]
        private static Transform[] hands = new Transform[2];

        [SerializeField]
        private static Transform[] legs = new Transform[2];

        [SerializeField]
        private static Transform chest;

        #endregion

        [SerializeField]
        private static Transform[] listOfBones;

        [SerializeField]
        private static VRCExpressionParameters baseAvatarExpressionParamater;

        [SerializeField]
        private static VRCExpressionParameters expressionParametersToMerge;

        private static Transform[] GetListOfBones()
        {
            return armature.GetComponentsInChildren<Transform>();
        }

        public static void DrawGUI()
        {
            VRCAvatarDescriptor = (VRCAvatarDescriptor)EditorGUILayout.ObjectField(
                "VRCAvatarDescriptor", VRCAvatarDescriptor, typeof(VRCAvatarDescriptor), true);

            avatarSkeleton = EditorGUILayout.Foldout(avatarSkeleton, "Armature");

            if (!avatarSkeleton)
                return;


            armature = (Transform)EditorGUILayout.ObjectField("Armature", armature, typeof(Transform), true);

            for (int i = 0; i < bodyParts.Length; i++)
            {
                bodyPartsTransform[i] = (Transform)EditorGUILayout.ObjectField(
                    bodyParts[i],
                    bodyPartsTransform[i],
                    typeof(Transform),
                    true
                    );
            }

            if (VRCAvatarDescriptor != null)
            {
                armature = VRCAvatarDescriptor.gameObject.transform.Find("Armature");
                listOfBones = GetListOfBones();

                foreach (Transform bone in listOfBones)
                {
                    switch (bone.gameObject.name)
                    {
                        case "Head":
                            bodyPartsTransform[0] = bone;
                            break;
                        case "Chest":
                            bodyPartsTransform[1] = bone;
                            break;
                        case "Left arm":
                            bodyPartsTransform[2] = bone;
                            break;
                        case "Right arm":
                            bodyPartsTransform[3] = bone;
                            break;
                        case "Left wrist":
                            bodyPartsTransform[4] = bone;
                            break;
                        case "Right wrist":
                            bodyPartsTransform[5] = bone;
                            break;
                        case "Left Leg":
                            bodyPartsTransform[6] = bone;
                            break;
                        case "Right Leg":
                            bodyPartsTransform[7] = bone;
                            break;
                        case "Left Ankle":
                            bodyPartsTransform[8] = bone;
                            break;
                        case "Right Ankle":
                            bodyPartsTransform[9] = bone;
                            break;
                        default:
                            break;
                    }

                }



            }
        }

        private List<GameObject> GetGameObjectWithSkinnedMeshRenderer(GameObject gameObject)
        {
            List<GameObject> skinnedMeshRendererGameObjectList = new List<GameObject>();

            return skinnedMeshRendererGameObjectList;
        }
    }
}
