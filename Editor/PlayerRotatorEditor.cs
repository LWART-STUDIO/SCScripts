
using GAME_MAIN.CodeBase.Logic;
using UnityEditor;
using UnityEngine;

namespace GAME_MAIN.Editor
{
    [CustomEditor(typeof(PlayerRotator))]
    public class PlayerRotatorEditor : UnityEditor.Editor
    {

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            PlayerRotator myScript = (PlayerRotator) target;

            if (GUILayout.Button("Move Up"))
            {
                myScript.MoveUp();
            }
        }
    }
}
