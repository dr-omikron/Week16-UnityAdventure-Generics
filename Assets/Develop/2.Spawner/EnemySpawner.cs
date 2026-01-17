using System;
using UnityEngine;

namespace Develop._2.Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        public void Spawn(EnemyConfig enemyConfig, Vector2Int spawnPosition)
        {
            switch (enemyConfig)
            {
                case OrkConfig orkConfig:

                    Ork ork = Instantiate(orkConfig.OrkPrefab, new Vector3(spawnPosition.x, 0, spawnPosition.y), Quaternion.identity);
                    ork.Initialize(orkConfig.Health, orkConfig.Damage);

                    break;

                case ElfConfig elfConfig:

                    Elf elf = Instantiate(elfConfig.ElfPrefab, new Vector3(spawnPosition.x, 0, spawnPosition.y), Quaternion.identity);
                    elf.Initialize(elfConfig.Health, elfConfig.Agility);

                    break;

                case DragonConfig dragonConfig:

                    Dragon dragon = Instantiate(dragonConfig.DragonPrefab, new Vector3(spawnPosition.x, 0, spawnPosition.y), Quaternion.identity);
                    dragon.Initialize(dragonConfig.Health, dragonConfig.Mana);

                    break;

                    default:
                        throw new ArgumentException("Invalid Enemy Config");
            }
        }
    }
}
