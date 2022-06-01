using UnityEngine;
using System.Collections.Generic;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A generator for level progression
    /// </summary>
    public class SpawnLevel : MonoBehaviour
    {

        public GameObject[] levelPrefabs;
        public LevelController firstLevel;
        [SerializeField]
        private float levelHeight = 12.5f;
        private LinkedList<LevelController> levels = new LinkedList<LevelController>();
        private int offsetToClean = 3;
        private bool needToDestroy => offsetToClean == 0;

        private void Awake()
        {
            var node = new LinkedListNode<LevelController>(firstLevel);
            levels.AddFirst(node);
        }

        public void SpawnNewLevel(GameObject trigger)
        {
            Vector3 position = new Vector3(trigger.transform.position.x, trigger.transform.position.y + levelHeight, trigger.transform.position.z);
            LevelController level = Instantiate(levelPrefabs[0], position, trigger.transform.rotation).GetComponent<LevelController>();
            level.spawnLevel.AddListener(SpawnNewLevel);

            var node = new LinkedListNode<LevelController>(level);
            levels.AddLast(node);

            if (offsetToClean > 0) offsetToClean -= 1;
            if (!needToDestroy) return;
            DestroyHead();
        }

        private void DestroyHead()
        {
            var node = levels.First;

            if(node != null)
            {
                Destroy(node.Value.gameObject);
            }

            levels.RemoveFirst();
        }
    }
}