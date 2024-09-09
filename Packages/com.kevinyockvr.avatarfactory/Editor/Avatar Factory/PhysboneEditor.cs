#define AvatarInteractions
using Kevin.VRChat.Base.Editor;
using UnityEditor;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Dynamics.PhysBone.Components;
public class PhysboneEditor : EditorBase
{
    private static readonly string[] physBoneGroups =
    {
        "Breast"
    };

    private static readonly string physbone = "Physbone";

    private static readonly string[] physBoneGroupName =
    {
            "Breasts",
            "Ass"
    };

    [SerializeField]
    private static GameObject go_physbone = null;

    [SerializeField]
    private VRCPhysBone VRCPhysBone;
    [SerializeField]
    private static VRCAvatarDescriptor VRCAvatarDescriptor;

    public static void DrawGUI()
    {

        VRCAvatarDescriptor = (VRCAvatarDescriptor)EditorGUILayout.ObjectField(
            "VRCAvatarDescriptor", VRCAvatarDescriptor, typeof(VRCAvatarDescriptor), true);

        GUILayout.BeginHorizontal();
        GUILayout.EndHorizontal();

        go_physbone = (GameObject)EditorGUILayout.ObjectField(
                "Physbone Label",
                go_physbone,
                typeof(GameObject),
                true
                );

        go_physbone = GameObject.Find(physbone);

    }

    public static void EditPhysbone(string physboneGroup ,VRCPhysBone[] m_physbones)
    {
        EditorGUILayout.LabelField(physboneGroup);
    }
}
