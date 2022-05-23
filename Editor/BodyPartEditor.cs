using GAME_MAIN.CodeBase.Logic;
using UnityEditor;
using UnityEngine;
using BodyPart = GAME_MAIN.CodeBase.Logic.BodyPart;

namespace GAME_MAIN.CodeBase.Editor
{
    [CustomEditor(typeof(BodyPart))]
    public class BodyPartEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();



            BodyPart myScript = (BodyPart) target;

            if (GUILayout.Button("HidePartAndReplace"))
            {
                myScript.HidePartAndReplace();
            }
        }
    }
}