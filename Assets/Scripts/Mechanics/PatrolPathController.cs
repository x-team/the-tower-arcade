using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A controller for objects for moving on a patrol mode on a path
    /// </summary>
    public class PatrolPathController : MoverController
    {
        public PatrolPath path;

        private Vector2 position;
        private float direction;
        private float defaultDirection = 1;

        private void Start()
        {
            if(path != null)
            {
                SetPath(path);
            }
        }
        public void SetPath(PatrolPath path)
        {
            this.path = path;
            transform.position = path.startAbsolutePosition;
            position = path.startAbsolutePosition;
            direction = defaultDirection;
        }

        internal override void Move()
        {
            base.Move();

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

                position.x = speed * direction;

                control.move.x = position.x;
            }
        }
    }
}