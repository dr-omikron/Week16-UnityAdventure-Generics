using System;
using UnityEngine;

namespace Develop._2.Spawner
{
    [Serializable]

    public class OrkConfig : EnemyConfig
    {
        [field: SerializeField] public int Damage { get; private set; }
    }
}
