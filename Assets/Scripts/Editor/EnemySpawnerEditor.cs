using CodeBase.GameLogic;
using UnityEditor;
using UnityEngine;

namespace CodeBase
{
    [CustomEditor(typeof(EnemySpawner))]
    public class EnemySpawnerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizoms(EnemySpawner spawner, GizmoType gizmoType)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spawner.transform.position, 0.5f);
        }
    }
}
