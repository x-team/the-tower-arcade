using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A generator for level progression
    /// </summary>
    public class SpawnLevel : MonoBehaviour
    {

        public GameObject[] levelPrefabs;

        public void SpawnNewLevel(GameObject trigger)
        {
            Instantiate(levelPrefabs[0], new Vector3(trigger.transform.position.x, trigger.transform.position.y + 20, trigger.transform.position.z), trigger.transform.rotation);
        }
    }
}