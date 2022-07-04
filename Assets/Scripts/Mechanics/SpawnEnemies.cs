using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Platformer.Mechanics
{
    public class SpawnEnemies : MonoBehaviour
    {
        [Serializable]
        public struct SpawnReference
        {
            [SerializeField]
            public EnemyPlaceholder.EnemyType type;
            public GameObject gameObject;
        }

        public SpawnReference[] spawnReferences;
        private Dictionary<EnemyPlaceholder.EnemyType, GameObject> prefabs;
        private Dictionary<EnemyPlaceholder.EnemyType, List<GameObject>> reusables;

        void Awake()
        {
            HashReferences();
        }

        private void HashReferences()
        {
            reusables = new Dictionary<EnemyPlaceholder.EnemyType, List<GameObject>>();
            prefabs = new Dictionary<EnemyPlaceholder.EnemyType, GameObject>();
            foreach(SpawnReference reference in spawnReferences)
            {
                prefabs.Add(reference.type, reference.gameObject);
                reusables.Add(reference.type, new List<GameObject>());
            }
        }

        public void SpawnEnemiesForLevel(LevelController level)
        {
            foreach(EnemyPlaceholder enemyPlaceholder in level.placeholders)
            {
                Spawn(enemyPlaceholder);
            }
        }

        private void Spawn(EnemyPlaceholder placeholder)
        {
            List<GameObject> reusableList = reusables[placeholder.type];
            if (reusableList.Count > 0)
            {
                GameObject gameObject = reusableList[reusableList.Count - 1];
                placeholder.Spawn(gameObject);
                reusableList.RemoveAt(reusableList.Count - 1);
            } else
            {
                GameObject prefab = prefabs[placeholder.type];

                if(prefab != null)
                {
                    GameObject gameObject = Instantiate(prefab, placeholder.transform);
                    placeholder.Spawn(gameObject);
                }
            }

        }
    }
}
    
