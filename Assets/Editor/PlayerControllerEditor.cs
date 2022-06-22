using Platformer.Mechanics;
using UnityEditor;
using UnityEngine;
namespace Platformer
{
    [CustomEditor(typeof(PlayerController))]
    public class PlayerControllerGizmo : Editor
    {
        public void OnSceneGUI()
        {
            var player = target as PlayerController;
            using (var cc = new EditorGUI.ChangeCheckScope())
            {
                
            }
        }

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        static void OnDrawGizmo(PlayerController player, GizmoType gizmoType)
        {
            Handles.color = Color.red;
            Handles.DrawWireArc(player.transform.position, Vector3.forward, Vector3.right, 180f, player.fieldOfViewDistance, 3f);
        }
    }
}