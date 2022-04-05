using UnityEngine;
using UnityEngine.Events;

namespace Platformer.Mechanics
{
    // <summary>
    /// A level instance
    /// </summary>
    public class LevelController : MonoBehaviour
    {
        private bool didTriggerNextLevel = false;
        public UnityEvent<GameObject> spawnLevel = new UnityEvent<GameObject>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (didTriggerNextLevel) return;

            var ply = collision.gameObject.GetComponent<PlayerController>();
            if(ply != null)
            {
                didTriggerNextLevel = true;
                spawnLevel.Invoke(gameObject);
            }
        }
    }
}