using System;
using UnityEngine;

namespace Develop._2.Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        public void Spawn(EnemyConfig enemyConfig, Vector2Int spawnPosition)
        {
            Enemy enemy;

            switch (enemyConfig)
            {
                case OrkConfig orkConfig:

                    enemy = Instantiate(orkConfig.EnemyPrefab, new Vector3(spawnPosition.x, 0, spawnPosition.y), Quaternion.identity);

                    if(enemy is Ork ork)
                        ork.Initialize(orkConfig.Health, orkConfig.Damage);

                    break;

                case ElfConfig elfConfig:

                    enemy = Instantiate(elfConfig.EnemyPrefab, new Vector3(spawnPosition.x, 0, spawnPosition.y), Quaternion.identity);

                    if(enemy is Elf elf)
                        elf.Initialize(elfConfig.Health, elfConfig.Agility);

                    break;

                case DragonConfig dragonConfig:

                    enemy = Instantiate(dragonConfig.EnemyPrefab, new Vector3(spawnPosition.x, 0, spawnPosition.y), Quaternion.identity);

                    if(enemy is Dragon dragon)
                        dragon.Initialize(dragonConfig.Health, dragonConfig.Mana);

                    break;

                    default:
                        throw new ArgumentException("Invalid Enemy Config");
            }
        }
    }
}
