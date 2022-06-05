using UnityEngine;


namespace Platformer.Mechanics
{
    /// <summary>
    /// An abstract class of a controller to move game objects on a path or route
    /// </summary>
    [RequireComponent(typeof(AnimationController))]
    public abstract class MoverController : MonoBehaviour
    {
        internal AnimationController control;

        internal float speed;

        /// <summary>
        /// This is called everytime on fixed update do move the object
        /// </summary>
        internal virtual void Move() { }

        void Awake()
        {
            control = GetComponent<AnimationController>();
            speed = control.maxSpeed * 0.5f;
        }


        private void FixedUpdate()
        {
            Move();
        }
    }

}
