using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Develop._2.Spawner
{
    [Serializable]
    public class EnemySettings
    {
        [SerializeField] private List<ElfConfig> _elfConfigs;
        [SerializeField] private List<OrkConfig> _orkConfigs;
        [SerializeField] private List<DragonConfig> _dragonConfigs;

        public EnemyConfig GetRandomConfigBy(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Ork:
                    return _orkConfigs[Random.Range(0, _orkConfigs.Count)]; 

                case EnemyType.Elf:
                    return _elfConfigs[Random.Range(0, _elfConfigs.Count)]; 

                case EnemyType.Dragon:
                    return _dragonConfigs[Random.Range(0, _dragonConfigs.Count)]; 

                default:
                    throw new ArgumentException("Invalid type");
            }
        }
    }
}
