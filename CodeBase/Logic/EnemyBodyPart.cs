using System;
using GAME_MAIN.CodeBase.StaticData;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class EnemyBodyPart:MonoBehaviour
    {
        [SerializeField] private BodyParts _type;
        [SerializeField] private BodyPart _bodyPart;
        [SerializeField] private EnemyControll _enemy;

        private void Awake()
        {
            _enemy = GetComponentInParent<EnemyControll>();
        }

        public void GetHit()
        {
            
            //_bodyPart.HidePartAndReplace();
            _enemy.TakeHit(_type);
        }
    }
}