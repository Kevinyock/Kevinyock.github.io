using UnityEngine;
using UnityEditor;
using VRC.SDK3.Avatars.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using static VRC.SDK3.Avatars.ScriptableObjects.VRCExpressionParameters;

namespace Kevin.VRChat.Base.Editor
{
    public class GoGoLocoInitialize : MonoBehaviour
    {
        private static readonly string[] m_GoGo_Loco_Parameters =
        {
            "Go/Float",
            "Go/PoseRadial",
            "Go/Stationary",
            "Go/Locomotion",
            "Go/Jump&Fall",
            "Go/StandIdle",
            "Go/CrouchIdle",
            "Go/ProneIdle",
            "Go/Height",
            "Go/PuppetX",
            "Go/PuppetY",
            "Go/Swimming"
        };

        [MenuItem("Assets/Create/KevinyockVR/Utilities/GoGo Loco/Go Beyond Parameters")]
        public static void AddGoBeyondParamaters()
        {
            VRCExpressionParameters expressionParameters = (VRCExpressionParameters)Selection.activeObject;

            List<Parameter> list_of_paramamters = expressionParameters.parameters.ToList();
            list_of_paramamters.Add(AddNewParamater(m_GoGo_Loco_Parameters[0],ValueType.Float,0f,false,true));
            list_of_paramamters.Add(AddNewParamater(m_GoGo_Loco_Parameters[1], ValueType.Float, 0f, false, false));
            list_of_paramamters.Add(AddNewParamater(m_GoGo_Loco_Parameters[2], ValueType.Bool, 0f, false, false));
            list_of_paramamters.Add(AddNewParamater(m_GoGo_Loco_Parameters[3], ValueType.Bool, 0f, true, false));
            list_of_paramamters.Add(AddNewParamater(m_GoGo_Loco_Parameters[4], ValueType.Bool, 0f, true, false));
            list_of_paramamters.Add(AddNewParamater(m_GoGo_Loco_Parameters[5], ValueType.Int, 0f, true, false));
            list_of_paramamters.Add(AddNewParamater(m_GoGo_Loco_Parameters[6], ValueType.Int, 0f, true, false));
            list_of_paramamters.Add(AddNewParamater(m_GoGo_Loco_Parameters[7], ValueType.Int, 0f, true, false));
            list_of_paramamters.Add(AddNewParamater(m_GoGo_Loco_Parameters[8], ValueType.Bool, 0f, false, false));
            list_of_paramamters.Add(AddNewParamater(m_GoGo_Loco_Parameters[9], ValueType.Float, 0f, false, false));
            list_of_paramamters.Add(AddNewParamater(m_GoGo_Loco_Parameters[10], ValueType.Float, 0f, false, false));
            list_of_paramamters.Add(AddNewParamater(m_GoGo_Loco_Parameters[11], ValueType.Float, 0f, false, true));

            expressionParameters.parameters = list_of_paramamters.ToArray();
        }

        private static Parameter AddNewParamater(string name, ValueType valueType, float defaultValue, bool saved, bool networkSynced)
        {
            Parameter parameter = new Parameter();
            parameter.name = name;
            parameter.valueType = valueType;
            parameter.saved = saved;
            parameter.defaultValue = defaultValue;
            parameter.networkSynced = networkSynced;
            return parameter;
        }
    }
}
