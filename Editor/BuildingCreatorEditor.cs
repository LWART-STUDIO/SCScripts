using GAME_MAIN.CodeBase.Logic;
using UnityEditor;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Editor
{
    [CustomEditor(typeof(BuildingCreator))]
    public class BuildingCreatorEditor:UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            BuildingCreator myScript = (BuildingCreator)target;
            if(GUILayout.Button("Create building"))
            {
                myScript.CreateBuilding();
            }
            if(GUILayout.Button("Destroy last building"))
            {
                myScript.DestroyBuilding();
            }
        }
    }
}