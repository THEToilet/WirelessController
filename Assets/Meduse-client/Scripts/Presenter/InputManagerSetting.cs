using UnityEditor;

namespace Meduse_client.Scripts
{
    /// <summary>
    /// 軸のタイプ
    /// </summary>
    public enum AxisType
    {
        KeyOrMouseButton = 0,
        MouseMovement = 1,
        JoystickAxis = 2
    };

    public class InputAxis
    {
        public string name = "";
        public string descriptiveName = "";
        public string descriptiveNegativeName = "";
        public string negativeButton = "";
        public string positiveButton = "";
        public string altNegativeButton = "";
        public string altPositiveButton = "";

        public float gravity = 0;
        public float dead = 0;
        public float sensitivity = 0;

        public bool snap = false;
        public bool invert = false;

        public AxisType type = AxisType.KeyOrMouseButton;

        // 使用する軸
        public int axis = 0;
        // 0なら全てのゲームパッドから取得される。1以降なら対応したゲームパッド。
        public int joyNum = 0;


        public static InputAxis CreateButton(string name, string positiveButton, string altPositiveButton)
        {
            var axis = new InputAxis();
            axis.name = name;
            axis.positiveButton = positiveButton;
            axis.altPositiveButton = altPositiveButton;
            axis.gravity = 0;
            axis.dead = 0.001f;
            axis.sensitivity = 0;
            axis.type = AxisType.KeyOrMouseButton;
            return axis;
        }

    }


    /// <summary>
    /// InputManagerを設定するためのクラス
    /// </summary>
    public class InputManagerGenerator
    {

        SerializedObject serializedObject;
        SerializedProperty axesProperty;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InputManagerGenerator()
        {
            // InputManager.assetをシリアライズされたオブジェクトとして読み込む
            serializedObject = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0]);
            axesProperty = serializedObject.FindProperty("m_Axes");
        }

        /// <summary>
        /// 軸を追加します。
        /// </summary>
        /// <param name="serializedObject">Serialized object.</param>
        /// <param name="axis">Axis.</param>
        public void AddAxis(InputAxis axis)
        {
            //if (axis.axis < 1) Debug.LogError("Axisは1以上に設定してください。");
            SerializedProperty axesProperty = serializedObject.FindProperty("m_Axes");

            axesProperty.arraySize++;
            serializedObject.ApplyModifiedProperties();

            SerializedProperty axisProperty = axesProperty.GetArrayElementAtIndex(axesProperty.arraySize - 1);

            GetChildProperty(axisProperty, "m_Name").stringValue = axis.name;
            GetChildProperty(axisProperty, "descriptiveName").stringValue = axis.descriptiveName;
            GetChildProperty(axisProperty, "descriptiveNegativeName").stringValue = axis.descriptiveNegativeName;
            GetChildProperty(axisProperty, "negativeButton").stringValue = axis.negativeButton;
            GetChildProperty(axisProperty, "positiveButton").stringValue = axis.positiveButton;
            GetChildProperty(axisProperty, "altNegativeButton").stringValue = axis.altNegativeButton;
            GetChildProperty(axisProperty, "altPositiveButton").stringValue = axis.altPositiveButton;
            GetChildProperty(axisProperty, "gravity").floatValue = axis.gravity;
            GetChildProperty(axisProperty, "dead").floatValue = axis.dead;
            GetChildProperty(axisProperty, "sensitivity").floatValue = axis.sensitivity;
            GetChildProperty(axisProperty, "snap").boolValue = axis.snap;
            GetChildProperty(axisProperty, "invert").boolValue = axis.invert;
            GetChildProperty(axisProperty, "type").intValue = (int)axis.type;
            GetChildProperty(axisProperty, "axis").intValue = axis.axis - 1;
            GetChildProperty(axisProperty, "joyNum").intValue = axis.joyNum;

            serializedObject.ApplyModifiedProperties();

        }

        /// <summary>
        /// 子要素のプロパティを取得します。
        /// </summary>
        /// <returns>The child property.</returns>
        /// <param name="parent">Parent.</param>
        /// <param name="name">Name.</param>
        private SerializedProperty GetChildProperty(SerializedProperty parent, string name)
        {
            SerializedProperty child = parent.Copy();
            child.Next(true);
            do
            {
                if (child.name == name) return child;
            }
            while (child.Next(false));
            return null;
        }

        /// <summary>
        /// 設定を全てクリアします。
        /// </summary>
        public void Clear()
        {
            axesProperty.ClearArray();
            serializedObject.ApplyModifiedProperties();
        }
    }

}
