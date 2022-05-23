using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GAME_MAIN.CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyTypeId, EnemyStaticData> _enemys;

        public void LoadEnemys()
        {
            _enemys = Resources.LoadAll<EnemyStaticData>("StaticData/Enemys")
                .ToDictionary(x => x.EnemyTypeId, x => x);
        }

        public EnemyStaticData ForEnemy(EnemyTypeId typeId) => 
            _enemys.TryGetValue(typeId, out EnemyStaticData staticData) ? staticData : null;
    }
}