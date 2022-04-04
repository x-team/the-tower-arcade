using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// DeathZone components mark a collider which will schedule a
    /// PlayerEnteredDeathZone event when the player enters the trigger.
    /// </summary>
    public class DeathZone : MonoBehaviour
    {
        private Rigidbody2D rigidBody;
        private float direction = 1;
        public float velocity = 1f;

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update () {
            rigidBody.velocity = new Vector2(0f, velocity * direction);
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredDeathZone>();
                ev.deathzone = this;
            } 
        }
    }
}