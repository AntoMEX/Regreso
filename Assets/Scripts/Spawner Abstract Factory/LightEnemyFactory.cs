using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemyFactory : EnemyFactory
{
    public GameObject lightEnemyPrefab;

    public override GameObject SpawnEnemy(Vector3 spawnPosition)
    {
        return Instantiate(lightEnemyPrefab, spawnPosition, Quaternion.identity);
    }
}

