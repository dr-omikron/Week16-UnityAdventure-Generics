using System;
using UnityEngine;

namespace Develop._2.Spawner
{
    [Serializable]

    public class EnemyConfig
    {
        [field: SerializeField] public int Health { get; private set; }
    }
}
