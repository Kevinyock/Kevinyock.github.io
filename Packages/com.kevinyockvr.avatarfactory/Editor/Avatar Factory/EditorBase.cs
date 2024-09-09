#if AvatarInteractions
using Kevin.VRChat.Base.Editor.Modules.AvatarInteraction;
#endif
using UnityEditor;
using UnityEngine;

namespace Kevin.VRChat.Base.Editor
{
    public class EditorBase : EditorWindow
    {
        private static string editorWindowTitle = "Kevinyock Avatar Editor";

        /// <summary>
        /// Path Directory when installing modules for the Editor
        /// </summary>
        private protected string modulePathDirectory = "";

        protected SerializedObject m_serializedObject;
        protected SerializedProperty m_serializedProperty;


        [SerializeField]
        private int menuIndex;

        [SerializeField]
        private static string[] m_ToolBarString =
        {
            "Avatar Interaction",
            "Physbone",
            "Avatar Animator"
        };

        [MenuItem("Tools/KevinyockVR/Kevin's Avatar Tools")]
        static void ShowWindow()
        {
            GetWindow<EditorBase>(editorWindowTitle);
        }

        void OnEnable()
        {
            m_serializedObject = new SerializedObject(this);
        }

        void OnGUI()
        {
            GUILayout.Label(editorWindowTitle);

            menuIndex = GUILayout.Toolbar(menuIndex, m_ToolBarString);
            switch (menuIndex)
            {
                case 0:
#if AvatarInteractions
                    AvatarInteractionModule.DrawGUI();
#else
                    MissingEditorModule("Avatar Interactions");
#endif
                    break;
                case 1:
#if PHYSBONE
                    PhysboneEditor.DrawGUI();
#else
                    MissingEditorModule("Physbone");
#endif
                    break;
                case 2:
#if AvatarController
                    AvatarControllerEditor.DrawGUI();
#else
                    MissingEditorModule("Avatar Controller");
#endif
                    break;
                default: 
                    break;
            }

            m_serializedObject.ApplyModifiedProperties();
        }

        void MissingEditorModule(string module_name)
        {
            EditorGUILayout.LabelField("Missing Module:" + module_name);
        }

    }
}
