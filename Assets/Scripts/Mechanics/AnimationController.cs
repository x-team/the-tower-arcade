using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using System.Linq;

namespace Platformer.Mechanics
{
    /// <summary>
    /// AnimationController integrates physics and animation. It is generally used for simple enemy animation.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
    public class AnimationController : KinematicObject
    {
        /// <summary>
        /// Horizontal speed.
        /// </summary>
        public float maxSpeed = 2;
        /// <summary>
        /// Max jump velocity
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        /// <summary>
        /// Used to indicated desired direction of travel.
        /// </summary>
        public Vector2 move;

        /// <summary>
        /// Set to true to initiate a jump.
        /// </summary>
        public bool jump;

        /// <summary>
        /// Set to true to set the current jump velocity to zero.
        /// </summary>
        public bool stopJump;

        SpriteRenderer spriteRenderer;
        Animator animator;
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        Transform[] childs;

        protected virtual void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            childs = transform.Cast<Transform>().ToArray();
        }

        protected override void ComputeVelocity()
        {
            if (canMoveOnYAxis)
            {
                if (jump && IsGrounded)
                {
                    velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                    jump = false;
                }
                else if (stopJump)
                {
                    stopJump = false;
                    if (velocity.y > 0)
                    {
                        velocity.y = velocity.y * model.jumpDeceleration;
                    }
                }
            }

            if (move.x > 0.01f)
            {
                spriteRenderer.flipX = false;
                foreach (Transform child in childs) {
                    child.rotation = Quaternion.identity;
                }
            }
            else if (move.x < -0.01f)
            {
                spriteRenderer.flipX = true;
                foreach (Transform child in childs)
                {
                    child.rotation = Quaternion.Euler(0, 180, 0);
                }
            }

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }
    }
}