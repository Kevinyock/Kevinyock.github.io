using UnityEditor;
using UnityEngine;
using VRC.Core;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace Kevin.VRChat.Base.Utilities
{
    public class AvatarTools : MonoBehaviour
    {
        [MenuItem("GameObject/Tools/Add Avatar Components")]
        private static void AddBaseAvatarComponent()
        {
            GameObject selectedObject = Selection.activeGameObject;

            if (selectedObject == null)
                return;

            if (selectedObject.GetComponent<PipelineManager>())
                return;

            if (selectedObject.GetComponent<VRCAvatarDescriptor>())
                return;

            selectedObject.AddComponent<PipelineManager>();
            selectedObject.AddComponent<VRCAvatarDescriptor>();

        }

        [MenuItem("Assets/Create/KevinyockVR/VRChat/Base Expression Parameters & Menu")]
        private static void BaseExpressionParametersAndMenu()
        {
            string currentSelectionPath = Common.GetProjectActiveDirectory();
            VRCExpressionsMenu expressionsMenu = CreateNewExpressionMenu();
            VRCExpressionParameters expressionParameters = CreateExpressionParameters();
            CreateExpressionMenuAsset(expressionsMenu, currentSelectionPath);
            ProjectWindowUtil.CreateAsset(expressionParameters, $"{currentSelectionPath}/{Application.productName} Expression Parameters.asset");
        }

        [MenuItem("Assets/Create/KevinyockVR/VRChat/Add Body Expression Menu")]
        private static void AddBodyExpressionMenu()
        {
            AddExpressionMenu("Body");
        }

        [MenuItem("Assets/Create/KevinyockVR/VRChat/Add 18+ Expression Menu")]
        private static void AddAdultOnlyExpressionMenu()
        {
            AddExpressionMenu("18+");
        }

        [MenuItem("Assets/Create/KevinyockVR/VRChat/Add Clothes Expression Menu")]
        private static void AddClothesExpressionMenu()
        {
            AddExpressionMenu("Clothes");
        }

        private static void AddExpressionMenu(string MenuName)
        {
            string currentSelectionPath = Common.GetProjectActiveDirectory();
            VRCExpressionsMenu expressionsMenu = CreateNewExpressionMenu();

            VRCExpressionsMenu n_expressionsMenu = CreateNewExpressionMenu();

            ProjectWindowUtil.CreateAsset(n_expressionsMenu, $"{currentSelectionPath}/{Application.productName} {MenuName}.asset");

            expressionsMenu.controls.Add(AddNewControl(n_expressionsMenu, MenuName));
        }

        // Broken
        [MenuItem("Assets/Create/KevinyockVR/VRChat/Add Reserved Expression Menu")]
        private static void AddReservedExpressionMenu()
        {
            string currentSelectionPath = Common.GetProjectActiveDirectory();
            VRCExpressionsMenu expressionsMenu = CreateNewExpressionMenu();

            CreateExpressionMenuAsset(expressionsMenu, currentSelectionPath);

            for (int i = 0; i < 8; i++)
            {
                VRCExpressionsMenu n_expressionsMenu = CreateNewExpressionMenu();
                expressionsMenu.controls.Add(AddNewControl(n_expressionsMenu, "Reserved"));
            }
        }

        [MenuItem("Assets/Create/KevinyockVR/VRChat/Set Control To SubMenu")]
        private static void SetReservedExpressionMenu()
        {
            VRCExpressionsMenu expressionsMenu = (VRCExpressionsMenu)Selection.activeObject;

            if (expressionsMenu == null) return;

            Debug.Log("We got the expression menu");
            
            int subMenuLength = expressionsMenu.controls.Count;

            for (int i = 0; i < subMenuLength; i++)
            {
                expressionsMenu.controls[i].type = VRCExpressionsMenu.Control.ControlType.SubMenu;
            }
        }

        [MenuItem("Assets/Create/KevinyockVR/VRChat/Create a SubMenu Template")]
        private static void CreateAllReservedExpression()
        {
            VRCExpressionsMenu expressionsMenu = CreateNewExpressionMenu();

            if (expressionsMenu == null) return;

            Debug.Log("We got the expression menu");


            for (int i = 0; i < 8; i++)
            {
                expressionsMenu.controls[i].type = VRCExpressionsMenu.Control.ControlType.SubMenu;
            }
        }

        private static VRCExpressionsMenu.Control AddNewControl(VRCExpressionsMenu submenu,string name)
        {
            VRCExpressionsMenu.Control control = new()
            {
                name = name,
                type = VRCExpressionsMenu.Control.ControlType.SubMenu
            };
            return control;
        }

        private static VRCExpressionsMenu CreateNewExpressionMenu()
        {
            return ScriptableObject.CreateInstance<VRCExpressionsMenu>();
        }

        private static VRCExpressionParameters CreateExpressionParameters()
        {
            return ScriptableObject.CreateInstance<VRCExpressionParameters>();
        }

        private static void CreateExpressionMenuAsset(VRCExpressionsMenu expressionsMenu, string currentSelectionPath)
        {
            ProjectWindowUtil.CreateAsset(expressionsMenu, $"{currentSelectionPath}/{Application.productName} Expression Menu.asset");
        }
    }
}