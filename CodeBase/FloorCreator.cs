using UnityEditor;
using UnityEngine;

namespace GAME_MAIN.CodeBase
{
    public class FloorCreator : MonoBehaviour
    {
        public GameObject FloorBase;
        public GameObject BigDoorwithSmallWindow;
        public GameObject GlassWall;
        public GameObject Roof;
        public GameObject Wall2;
        public GameObject Wallwitth2window;
        public GameObject Wallwitth2BigWindow;
        public GameObject WallwithBigWindow;
        public GameObject Wall1;

        
        
        
        
        private GameObject _floorBase;
        private GameObject _walls;
        private GameObject _furniture;
        private GameObject _enemy;
        public void CreateBase()
        {
            if (_floorBase != null) 
                DestroyFloor();
            
            _floorBase = new GameObject();
            _floorBase.name = $"Floor";

            _walls = new GameObject();
            _walls.name = "Walls";
            _walls.transform.SetParent(_floorBase.transform);

            _furniture = new GameObject();
            _furniture.name = "Furniture";
            _furniture.transform.SetParent(_floorBase.transform);
            
            _enemy = new GameObject();
            _enemy.name = "Enemy";
            _enemy.transform.SetParent(_floorBase.transform);
            
            
            GameObject floor=null;
            //floor = PrefabUtility.InstantiatePrefab(FloorBase, _floorBase.transform) as GameObject;
            floor.transform.position=Vector3.zero;
        }

        public void CreateBigDoorwithSmallWindow()
        {
            GameObject floor=null;
            //floor = PrefabUtility.InstantiatePrefab(BigDoorwithSmallWindow, _walls.transform) as GameObject;
            floor.transform.position=Vector3.zero;
        }
        public void CreateGlassWall()
        {
            GameObject floor=null;
           // floor = PrefabUtility.InstantiatePrefab(GlassWall, _walls.transform) as GameObject;
            floor.transform.position=Vector3.zero;
        }
        public void CreateRoof()
        {
            GameObject floor=null;
           // floor = PrefabUtility.InstantiatePrefab(Roof, _walls.transform) as GameObject;
            floor.transform.position=Vector3.zero;
        }
        public void CreateWall2()
        {
            GameObject floor=null;
           // floor = PrefabUtility.InstantiatePrefab(Wall2, _walls.transform) as GameObject;
            floor.transform.position=Vector3.zero;
        }
        public void CreateWallwitth2window()
        {
            GameObject floor=null;
          //  floor = PrefabUtility.InstantiatePrefab(Wallwitth2window, _walls.transform) as GameObject;
            floor.transform.position=Vector3.zero;
        } public void CreateWallwith2Bigwindow()
        {
            GameObject floor=null;
           // floor = PrefabUtility.InstantiatePrefab(Wallwitth2BigWindow, _walls.transform) as GameObject;
            floor.transform.position=Vector3.zero;
        }
        public void CreateWallwithBigWindow()
        {
            GameObject floor=null;
            //floor = PrefabUtility.InstantiatePrefab(WallwithBigWindow, _walls.transform) as GameObject;
            floor.transform.position=Vector3.zero;
        }
        public void CreateWall1()
        {
            GameObject floor=null;
            //floor = PrefabUtility.InstantiatePrefab(Wall1, _walls.transform) as GameObject;
            floor.transform.position=Vector3.zero;
        }
        public void DestroyFloor()
        {
            if (_floorBase != null)
            {
                DestroyImmediate(_floorBase);

            }
        }
    }
}
