using System;
using UnityEngine;

namespace Develop._2.Spawner
{
    [Serializable]

    public class ElfConfig : EnemyConfig
    {
        [field: SerializeField] public Elf ElfPrefab { get; private set; }
        [field: SerializeField] public int Agility { get; private set; }
    }
}
