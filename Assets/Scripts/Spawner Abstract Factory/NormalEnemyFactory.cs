using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyFactory : EnemyFactory
{
    public GameObject normalEnemyPrefab;

    public override GameObject SpawnEnemy(Vector3 spawnPosition)
    {
        //Instancia del prefab en la posición indicada
        return Instantiate(normalEnemyPrefab, spawnPosition, Quaternion.identity);
    }
}

