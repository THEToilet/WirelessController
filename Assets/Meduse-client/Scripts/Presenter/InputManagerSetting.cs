using UnityEditor;

namespace Meduse_client.Scripts
{
    /// <summary>
    /// ���̃^�C�v
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

        // �g�p���鎲
        public int axis = 0;
        // 0�Ȃ�S�ẴQ�[���p�b�h����擾�����B1�ȍ~�Ȃ�Ή������Q�[���p�b�h�B
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
    /// InputManager��ݒ肷�邽�߂̃N���X
    /// </summary>
    public class InputManagerGenerator
    {

        SerializedObject serializedObject;
        SerializedProperty axesProperty;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public InputManagerGenerator()
        {
            // InputManager.asset���V���A���C�Y���ꂽ�I�u�W�F�N�g�Ƃ��ēǂݍ���
            serializedObject = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0]);
            axesProperty = serializedObject.FindProperty("m_Axes");
        }

        /// <summary>
        /// ����ǉ����܂��B
        /// </summary>
        /// <param name="serializedObject">Serialized object.</param>
        /// <param name="axis">Axis.</param>
        public void AddAxis(InputAxis axis)
        {
            //if (axis.axis < 1) Debug.LogError("Axis��1�ȏ�ɐݒ肵�Ă��������B");
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
        /// �q�v�f�̃v���p�e�B���擾���܂��B
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
        /// �ݒ��S�ăN���A���܂��B
        /// </summary>
        public void Clear()
        {
            axesProperty.ClearArray();
            serializedObject.ApplyModifiedProperties();
        }
    }

}
