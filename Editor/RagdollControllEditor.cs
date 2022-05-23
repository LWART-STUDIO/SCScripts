using GAME_MAIN.CodeBase.Logic;
using UnityEditor;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Editor
{
    [CustomEditor(typeof(RagdollControll))]
    public class RagdollControllEditor:UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            RagdollControll myScript = (RagdollControll)target;

            if (GUILayout.Button("SetUp Ragdoll"))
            {
                myScript.SetUpRagoll();
            }
            if (GUILayout.Button("Turn Off"))
            {
                myScript.TurnOff();
            }
            if (GUILayout.Button("Turn On"))
            {
                myScript.TurnOn();
            }
        }
    }
}