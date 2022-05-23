using GAME_MAIN.CodeBase.Logic;
using UnityEditor;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Editor
{
    [CustomEditor(typeof(EnemySpawner))]
    public class EnemySpawnerEditor:UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGismo(EnemySpawner spawner, GizmoType gizmo)
        {
            Gizmos.color=Color.red;
            Gizmos.DrawSphere(spawner.transform.position,0.5f);
            
        }
    }
}