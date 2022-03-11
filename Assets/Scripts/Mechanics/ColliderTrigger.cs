using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer.Mechanics
{
    // <summary>
    /// A simple trigger for colliders
    /// </summary>
    public class ColliderTrigger : MonoBehaviour
    {
        public UnityEvent<Collider2D> eventTrigger = new UnityEvent<Collider2D>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            eventTrigger.Invoke(collision);
        }
    }
}
