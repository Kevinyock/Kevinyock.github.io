using UnityEditor;
using UnityEngine;

namespace Kevin.VRChat.Base.Editor
{
    public class AvatarControllerEditor : EditorBase
    {
        public static Animator main_animator;
        public static Animator animator_to_merge_from;
        public static void DrawGUI()
        {
            main_animator = (Animator)EditorGUILayout.ObjectField("Animator", main_animator, typeof(Animator), true);
            //VRCAvatarDescriptor = (VRCAvatarDescriptor)EditorGUILayout.ObjectField(
            //    "VRCAvatarDescriptor", VRCAvatarDescriptor, typeof(VRCAvatarDescriptor), true);
        }

        private static void ResetAnimatorParameters(Animator animator)
        {
            AnimatorControllerParameter[] parameters= new AnimatorControllerParameter[] { };
            //animator. = parameters;
        }
    }
}
