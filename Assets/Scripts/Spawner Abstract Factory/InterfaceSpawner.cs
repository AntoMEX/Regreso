using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemySpawner
{
    GameObject SpawnEnemy(Vector3 spawnPosition);
}

