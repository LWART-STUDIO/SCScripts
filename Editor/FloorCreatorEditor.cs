using UnityEditor;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Editor
{
    [CustomEditor(typeof(FloorCreator))]
    public class FloorCreatorEditor : UnityEditor.Editor
    {
        private UnityEditor.Editor objectEditor;
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            
         
            FloorCreator myScript = (FloorCreator)target;
           
            if(GUILayout.Button("Create"))
            {
                myScript.CreateBase();
            }
            Drawbject(myScript.FloorBase);
            if(GUILayout.Button("Create"))
            {
                myScript.CreateBigDoorwithSmallWindow();
            }
            Drawbject(myScript.BigDoorwithSmallWindow);
            if(GUILayout.Button("Create"))
            {
                myScript.CreateGlassWall();
            }
            Drawbject(myScript.GlassWall);
            if(GUILayout.Button("Create"))
            {
                myScript.CreateRoof();
            }
            Drawbject(myScript.Roof);
            if(GUILayout.Button("Create"))
            {
                myScript.CreateWall2();
            }
            Drawbject(myScript.Wall2);
            if(GUILayout.Button("Create"))
            {
                myScript.CreateWallwitth2window();
            }
            Drawbject(myScript.Wallwitth2window);
            if(GUILayout.Button("Create"))
            {
                myScript.CreateWallwith2Bigwindow();
            }
            Drawbject(myScript.Wallwitth2BigWindow);
            if(GUILayout.Button("Create"))
            {
                myScript.CreateWallwithBigWindow();
            }
            Drawbject(myScript.WallwithBigWindow);
            if(GUILayout.Button("Create"))
            {
                myScript.CreateWall1();
            }
            Drawbject(myScript.Wall1);
            
            if(GUILayout.Button("Destroy last building"))
            {
                myScript.DestroyFloor();
            }
        }

        public void Drawbject(GameObject model)
        {
            Texture2D previewBackgroundTexture=null;
            GameObject newObject=null;
            //newObject = (GameObject) EditorGUILayout.ObjectField(newObject, typeof(GameObject), true);
            if(EditorGUI.EndChangeCheck())
            {
                if(objectEditor != null) DestroyImmediate(objectEditor);
            }
            GUIStyle bgColor = new GUIStyle();
   
            bgColor.normal.background = previewBackgroundTexture;

            newObject = model;
            if (newObject != null)
            {
                if (objectEditor == null)
                    objectEditor = UnityEditor.Editor.CreateEditor(newObject);
                
                objectEditor.OnInteractivePreviewGUI(GUILayoutUtility.GetRect (100,100),bgColor);
            }
        }
    }
}
