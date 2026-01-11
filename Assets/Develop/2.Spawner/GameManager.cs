using System;
using UnityEngine;

namespace Develop._2.Spawner
{
    public class GameManager : MonoBehaviour
    {
        private const int SpawnEnemyCount = 3;

        [SerializeField] private EnemySettings _enemySettings;
        [SerializeField] private EnemySpawner _enemySpawner;

        private void Awake()
        {
            int enemyTypesCount = Enum.GetValues(typeof(EnemyType)).Length;

            for (int i = 0; i < enemyTypesCount; i++)
            {
                for (int j = 0; j < SpawnEnemyCount; j++)
                {
                    EnemyConfig config = _enemySettings.GetRandomConfigBy((EnemyType)i);
                    _enemySpawner.Spawn(config, new Vector2Int(i, j));
                }
            }
        }
    }
}
