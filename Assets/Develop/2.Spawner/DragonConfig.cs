using System;
using UnityEngine;

namespace Develop._2.Spawner
{
    [Serializable]

    public class DragonConfig : EnemyConfig
    {
        [field: SerializeField] public float Mana { get; private set; }
    }
}
