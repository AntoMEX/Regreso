using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighEnemyFactory : EnemyFactory
{
    public GameObject highEnemyPrefab;

    public override GameObject SpawnEnemy(Vector3 spawnPosition)
    {
        return Instantiate(highEnemyPrefab, spawnPosition, Quaternion.identity);
    }
}

