using System;
using UnityEngine;

namespace Develop._2.Spawner
{
    [Serializable]

    public class EnemyConfig
    {
        [field: SerializeField] public Enemy EnemyPrefab { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
    }
}
