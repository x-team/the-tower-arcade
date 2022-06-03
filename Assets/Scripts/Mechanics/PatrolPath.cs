using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This component is used to create a patrol path, two points which enemies will move between.
    /// </summary>
    public partial class PatrolPath : MonoBehaviour
    {
        /// <summary>
        /// One end of the patrol path.
        /// </summary>
        public Vector2 startPosition, endPosition;

        public Vector2 startAbsolutePosition;
        public Vector2 endAbsolutePosition;

        private void Awake()
        {
            startAbsolutePosition = new Vector2(transform.position.x, transform.position.y) + startPosition;
            endAbsolutePosition = new Vector2(transform.position.x, transform.position.y) + endPosition;
        }

        void Reset()
        {
            startPosition = Vector3.left;
            endPosition = Vector3.right;
        }
    }
}