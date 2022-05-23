
using UnityEngine;

namespace GAME_MAIN.CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "EnemyData",menuName = "StaticData/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {

        public EnemyTypeId EnemyTypeId;
        public int Hp;
        public int Armor;
        public float Damage;
        public GameObject ModelPrefab;
        public GameObject GunPrefub;
    }
}
