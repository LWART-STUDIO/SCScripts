using System;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

namespace GAME_MAIN.CodeBase.Logic
{
    public class BuildingCreator : MonoBehaviour
    {
        [SerializeField] private int _numberOfFloors;
        [SerializeField,Range(1,3)] private int _buildngHardLevel;
        [SerializeField] private bool _haveBoss;
        [SerializeField] private bool _haveStairs;
        [SerializeField] private int _levelOfStairs;
        [SerializeField] private float _step;
        [SerializeField] private List<BuildingBaseFloor> _floorsPrefubs;
        private GameObject _buildingBase;
        private GameObject _previusFloor;
        private int _stairsLevel;

        public void CreateBuilding()
        {
            if (_buildingBase != null) 
                DestroyBuilding();

            if (_levelOfStairs <= 1 || _levelOfStairs > _numberOfFloors-2 &&_haveStairs)
            {
                _stairsLevel = UnityEngine.Random.Range(2, _numberOfFloors - 2);
            }
            else
            {
                _stairsLevel = _levelOfStairs;
            }

            _buildingBase = new GameObject();
            BuildingInfo buildingInfo = _buildingBase.AddComponent<BuildingInfo>();
            buildingInfo.BuildingHard = _buildngHardLevel;
            buildingInfo.HaveBoss = _haveBoss;
            buildingInfo.NumberOfFloors = _numberOfFloors;
            _buildingBase.name = $"Building Floors={_numberOfFloors}_HardLevel={_buildngHardLevel}_HaveBoss={_haveBoss}";

            NavMeshSurface navMeshSurface = _buildingBase.AddComponent<NavMeshSurface>();
            for (int currentFloorNumber = 0; currentFloorNumber < _numberOfFloors; currentFloorNumber++)
            {
                if (currentFloorNumber == 0)
                    CreateFirstFloor(currentFloorNumber);
                
                else if (currentFloorNumber == _numberOfFloors - 1)
                    CreateEndFloor(currentFloorNumber);
                
                else if (_haveStairs && currentFloorNumber > 0 && currentFloorNumber < _numberOfFloors - 2&&currentFloorNumber==_stairsLevel-1)
                    currentFloorNumber = CreateStairFloor(currentFloorNumber);
                
                else
                    CreateMiddleFloor(currentFloorNumber);
            }
            navMeshSurface.BuildNavMesh();
        }

        private void CreateMiddleFloor(int currentFloorNumber)
        {
            GameObject floor=null;
            /*floor = PrefabUtility.InstantiatePrefab(
                _floorsPrefubs[_buildngHardLevel - 1]
                    .MiddleFloorPrefabs[
                        UnityEngine.Random.Range(0, _floorsPrefubs[_buildngHardLevel - 1].MiddleFloorPrefabs.Count)],
                _buildingBase.transform) as GameObject;*/
            floor.name = $"{currentFloorNumber+1}_Floor";
            Vector3 position = Vector3.zero;
            if (_previusFloor != null)
            {
                position = _previusFloor.transform.position + new Vector3(0, _step, 0);
            }

            floor.transform.localPosition = position;
            _previusFloor = floor;
        }

        private int CreateStairFloor(int currentFloorNumber)
        {
            GameObject floor=null;
            int index = UnityEngine.Random.Range(0,
                _floorsPrefubs[_buildngHardLevel - 1].BuildingStairsFloors.Count);
            /*floor = PrefabUtility.InstantiatePrefab(
                _floorsPrefubs[_buildngHardLevel - 1].BuildingStairsFloors[index].FirstFloor,
                _buildingBase.transform) as GameObject;*/
            floor.name = $"{currentFloorNumber+1}_Floor";
            Vector3 position = Vector3.zero;
            if (_previusFloor != null)
            {
                position = _previusFloor.transform.position + new Vector3(0, _step, 0);
            }

            floor.transform.localPosition = position;
            _previusFloor = floor;
            currentFloorNumber++;
            /*floor = PrefabUtility.InstantiatePrefab(
                _floorsPrefubs[_buildngHardLevel - 1].BuildingStairsFloors[index].SecondFloor,
                _buildingBase.transform) as GameObject;*/
            floor.name = $"{currentFloorNumber+1}_Floor";
            if (_previusFloor != null)
                position = _previusFloor.transform.position + new Vector3(0, _step, 0);

            floor.transform.localPosition = position;
            _previusFloor = floor;
            return currentFloorNumber;
        }

        private void CreateEndFloor(int currentFloorNumber)
        {
            GameObject floor=null;
           // if (!_haveBoss)
                /*floor = PrefabUtility.InstantiatePrefab(
                    _floorsPrefubs[_buildngHardLevel - 1].
                        EndFloorPrefabs[UnityEngine.Random.Range(0, _floorsPrefubs[_buildngHardLevel - 1].EndFloorPrefabs.Count)],
                    _buildingBase.transform) as GameObject;*/
           // else
                /*floor = PrefabUtility.InstantiatePrefab(
                    _floorsPrefubs[_buildngHardLevel - 1].EndBossFloorPrefabs[UnityEngine.Random.Range(0, _floorsPrefubs[_buildngHardLevel - 1].
                        EndBossFloorPrefabs.Count)],
                    _buildingBase.transform) as GameObject;*/

            floor.name = $"{currentFloorNumber+1}_Floor";
            Vector3 position = Vector3.zero;
            if (_previusFloor != null)
            {
                position = _previusFloor.transform.position + new Vector3(0, _step, 0);
            }

            floor.transform.localPosition = position;
            _previusFloor = floor;
        }

        private void CreateFirstFloor(int currentFloorNumber)
        {
            GameObject floor=null;
            /*floor = PrefabUtility.InstantiatePrefab(
                _floorsPrefubs[_buildngHardLevel - 1]
                    .StartFloorPrefabs[
                        UnityEngine.Random.Range(0, _floorsPrefubs[_buildngHardLevel - 1].StartFloorPrefabs.Count)],
                _buildingBase.transform) as GameObject;*/
            floor.name = $"{currentFloorNumber+1}_Floor";
            floor.transform.localPosition=Vector3.zero;
            _previusFloor = floor;
        }

        public void DestroyBuilding()
        {
            if (_buildingBase != null)
            {
                DestroyImmediate(_buildingBase);

            }
        }
       
    }

    [Serializable]
    public class BuildingBaseFloor
    {
        public int Level;
        public List<GameObject> StartFloorPrefabs;
        public List<GameObject> MiddleFloorPrefabs;
        public List<GameObject> EndFloorPrefabs;
        public List<GameObject> EndBossFloorPrefabs;
        public List<BuildingStayersFloor> BuildingStairsFloors;
    }

    [Serializable]
    public class BuildingStayersFloor
    {
        public GameObject FirstFloor;
        public GameObject SecondFloor;
    }
}
