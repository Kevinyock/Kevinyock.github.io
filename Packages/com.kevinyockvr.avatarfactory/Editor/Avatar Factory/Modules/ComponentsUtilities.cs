using UnityEditor;
using UnityEngine;

public class ComponentsUtilities : MonoBehaviour
{
    [MenuItem("GameObject/Tools/Components/List Components", false, 0)]
    private static void ListComponents()
    {
        GameObject selectedGameObject = Selection.activeGameObject;
        Component[] components = selectedGameObject.GetComponents<Component>();
        foreach (Component component in components)
        {
            Debug.Log(component);
        }
    }

    [MenuItem("GameObject/Tools/Components/Reset All Components", false, 0)]
    private static void ResetAllComponents()
    {
        string title = "Reset all GameObject Components";
        string message = "You will lose all of your configuration after making this change, are you sure?";
        string ok = "Yes, Reset";
        string cancel = "Cancel";

        GameObject selectedGameObject = Selection.activeGameObject;

        bool reset = EditorUtility.DisplayDialog(title,message,ok,cancel);

        if (!reset)
            return;

        Component[] components = selectedGameObject.GetComponents<Component>();
        foreach (Component component in components)
        {
            Unsupported.SmartReset(component);
        }

        Debug.Log("Reset all Components");

    }

}
