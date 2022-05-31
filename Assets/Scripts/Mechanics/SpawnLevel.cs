using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A generator for level progression
    /// </summary>
    public class SpawnLevel : MonoBehaviour
    {

        public GameObject[] levelPrefabs;
        [SerializeField]
        private float levelHeight = 12.5f;

        public void SpawnNewLevel(GameObject trigger)
        {
            Vector3 position = new Vector3(trigger.transform.position.x, trigger.transform.position.y + levelHeight, trigger.transform.position.z);
            LevelController level = Instantiate(levelPrefabs[0], position, trigger.transform.rotation).GetComponent<LevelController>();
            level.spawnLevel.AddListener(SpawnNewLevel);
        }
    }
}