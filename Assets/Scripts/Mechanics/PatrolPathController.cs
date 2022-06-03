using UnityEngine;

namespace Platformer.Mechanics
{
    public class PatrolPathController : MonoBehaviour
    {
        public PatrolPath path;
        internal AnimationController control;
        private Vector2 position;
        private float direction;
        private float defaultDirection = 1;
        private float speed;

        void Awake()
        {
            control = GetComponent<AnimationController>();
            speed = control.maxSpeed * 0.5f;
        }

        private void Start()
        {
            transform.position = path.startAbsolutePosition;
            position = path.startAbsolutePosition;
            direction = defaultDirection;
        }

        private void FixedUpdate()
        {
            if (path != null)
            {
                
                if (transform.position.x <= path.startAbsolutePosition.x)
                {
                    direction = 1;
                }
                else if (transform.position.x >= path.endAbsolutePosition.x)
                {
                    direction = -1;
                }

                float distance = speed * direction;
                position.x = distance;
                
                control.move.x = position.x;
            }
        }

    }
}